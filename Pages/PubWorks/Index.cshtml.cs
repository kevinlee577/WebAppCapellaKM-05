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

        public IList<PubWork> PubWork { get;set; }

        public async Task OnGetAsync()
        {
            //    PubWork = await _context.PubWork.ToListAsync();
            PubWork = await _context.PubWork
                 .Include(c => c.Publication)
                 .Include(d => d.Author)
                 .AsNoTracking()
                 .ToListAsync();
        }

        public Publication Publication { get; set; }
        public Author Author { get; set; }

    }
}
