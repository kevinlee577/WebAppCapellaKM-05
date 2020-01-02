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
    public class DetailsModel : PageModel
    {
        private readonly WebAppCapellaKM_05.Data.ApplicationDbContext _context;

        public DetailsModel(WebAppCapellaKM_05.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Publication Publication { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

        //    Publication = await _context.Publication.FirstOrDefaultAsync(m => m.PublicationID == id);
         
            Publication = await _context.Publication
            .Include(s => s.Articles)
            .ThenInclude(e => e.Author)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.PublicationID == id);

            if (Publication == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
