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
    public class DetailsModel : PageModel
    {
        private readonly WebAppCapellaKM_05.Data.ApplicationDbContext _context;

        public DetailsModel(WebAppCapellaKM_05.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public PubWork PubWork { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

        //    PubWork = await _context.PubWork.FirstOrDefaultAsync(m => m.PubWorkKeyID == id);

            PubWork = await _context.PubWork
            .Include(s => s.Publication)
            .Include(e => e.Author)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.PubWorkKeyID == id);

            if (PubWork == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
