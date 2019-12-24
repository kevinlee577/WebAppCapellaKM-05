using WebAppCapellaKM_05.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebAppCapellaKM_05.Pages.PubWorks
{
    public class AuthorNamePageModel : PageModel
    {
        public SelectList AuthorNameSL { get; set; }

        public void PopulateAuthorsDropDownList(ApplicationDbContext _context,
            object selectedAuthor = null)
        {
            var authorsQuery = from d in _context.Author
                                    orderby d.AuthorLastName // Sort by name.
                                    select d;

            AuthorNameSL = new SelectList(authorsQuery.AsNoTracking(),
                        "AuthorID", "AuthorName", selectedAuthor);
        }
    }
}
