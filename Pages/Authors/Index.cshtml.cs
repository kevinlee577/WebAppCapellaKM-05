using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCapellaKM_05.Data;
using WebAppCapellaKM_05.Models;

namespace WebAppCapellaKM_05.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly WebAppCapellaKM_05.Data.ApplicationDbContext _context;

        public IndexModel(WebAppCapellaKM_05.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Author> Author { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<Author> studentsIQ = from s in _context.Author
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.AuthorLastName.Contains(searchString)
                                       || s.AuthorFirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.AuthorLastName);
                    break;
                case "Date":
                    studentsIQ = studentsIQ.OrderBy(s => s.AuthorLastName);
                    break;
                case "date_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.AuthorLastName);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.AuthorLastName);
                    break;
            }


            //   Author = await _context.Author.ToListAsync();
                Author = await studentsIQ.AsNoTracking().ToListAsync();
        }
    }
}
