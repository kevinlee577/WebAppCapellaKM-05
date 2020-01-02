using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCapellaKM_05.Data;
using WebAppCapellaKM_05.Models;

namespace WebAppCapellaKM_05.Pages.PubWorks
{
    public class IndexModel : PublicationNamePageModel
    {
        private readonly WebAppCapellaKM_05.Data.ApplicationDbContext _context;

        public IndexModel(WebAppCapellaKM_05.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentFilter2 { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<PubWork> PubWork { get; set; }

    //    public IList<PubWork> PubWork { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex, string searchString2)
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

            IQueryable<PubWork> studentsIQ = from s in _context.PubWork
                                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.PubWorkName.Contains(searchString));
                                    
            }

            if (searchString2 != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString2 = currentFilter;
            }

            CurrentFilter2 = searchString2;

        //    IQueryable<PubWork> studentsIQ = from s in _context.PubWork
        //                                     select s;

            if (!String.IsNullOrEmpty(searchString2))
            {
                studentsIQ = studentsIQ.Where(s => s.PubWorkKeyPhrases.Contains(searchString2));

            }

            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.PubWorkName);
                    break;
                case "Date":
                    studentsIQ = studentsIQ.OrderBy(s => s.PubWorkName);
                    break;
                case "date_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.PubWorkName);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.PubWorkName);
                    break;
            }

                int pageSize = 5;

                PubWork = await PaginatedList<PubWork>.CreateAsync(
                studentsIQ.Include(d => d.Author).Include(c => c.Publication).AsNoTracking(),
                pageIndex ?? 1,
                pageSize);

            //    PubWork = await _context.PubWork.ToListAsync();
            //    PubWork = await _context.PubWork
            //        .Include(c => c.Publication)
            //        .Include(d => d.Author)
            //        .AsNoTracking()
            //        .ToListAsync();
        }

        public Publication Publication { get; set; }
        public Author Author { get; set; }

    }
}
