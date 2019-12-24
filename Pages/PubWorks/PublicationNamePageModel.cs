using WebAppCapellaKM_05.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebAppCapellaKM_05.Pages.PubWorks
{
    public class PublicationNamePageModel : PageModel
    {
        public SelectList PublicationNameSL { get; set; }

        public void PopulatePublicationsDropDownList(ApplicationDbContext _context,
            object selectedPublication = null)
        {
            var publicationsQuery = from d in _context.Publication
                                    orderby d.PublicationName // Sort by name.
                                    select d;

            PublicationNameSL = new SelectList(publicationsQuery.AsNoTracking(),
                        "PublicationID", "PublicationName", selectedPublication);
        }

        public SelectList AuthorNameSL { get; set; }

     //   public string AuthorName { get; set; }

        public void PopulateAuthorsDropDownList(ApplicationDbContext _context,
            object selectedAuthor = null)
        {
            var authorsQuery = from d in _context.Author
                                    orderby d.AuthorLastName // Sort by name.
                                    select d;

            AuthorNameSL = new SelectList(authorsQuery.AsNoTracking(),
                        "AuthorID", "AuthorLastName", selectedAuthor);
        }

    }  
}
