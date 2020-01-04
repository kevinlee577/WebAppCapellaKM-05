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
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentFilter1 { get; set; }
        public string CurrentFilter3 { get; set; }

        public PaginatedList<PubWork> PubWork { get; set; }

    //    public IList<PubWork> PubWork { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, int? pageIndex, string searchString)
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

            IQueryable<PubWork> articlesIQ = from s in _context.PubWork
                                             select s;

                                

            if (!String.IsNullOrEmpty(searchString))
            {
                articlesIQ = articlesIQ.Where(s => s.PubWorkName.Contains(searchString)
                                        || s.PubWorkKeyPhrases.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "name_desc":
                    articlesIQ = articlesIQ.OrderByDescending(s => s.PubWorkName);
                    break;
                case "Date":
                    articlesIQ = articlesIQ.OrderBy(s => s.PubWorkName);
                    break;
                case "date_desc":
                    articlesIQ = articlesIQ.OrderByDescending(s => s.PubWorkName);
                    break;
                default:
                    articlesIQ = articlesIQ.OrderBy(s => s.PubWorkName);
                    break;
            }

                int pageSize = 5;

                PubWork = await PaginatedList<PubWork>.CreateAsync(
                articlesIQ.Include(d => d.Author).Include(c => c.Publication).AsNoTracking(),
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
