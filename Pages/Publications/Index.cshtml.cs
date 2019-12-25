using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCapellaKM_05.Data;
using WebAppCapellaKM_05.Models;

namespace WebAppCapellaKM_05.Pages.Publications
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

        public PaginatedList<Publication> Publication { get; set; }

    //    public IList<Publication> Publication { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Publication> studentsIQ = from s in _context.Publication
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.PublicationName.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.PublicationName);
                    break;
                case "Date":
                    studentsIQ = studentsIQ.OrderBy(s => s.PublicationName);
                    break;
                case "date_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.PublicationName);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.PublicationName);
                    break;
            }

                int pageSize = 5;

                Publication = await PaginatedList<Publication>.CreateAsync(
                studentsIQ.AsNoTracking(),
                pageIndex ?? 1,
                pageSize);

            //   Publication = await _context.Publication.ToListAsync();


        }
    }
}
