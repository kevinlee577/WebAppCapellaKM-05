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
    public class DeleteModel : PageModel
    {
        private readonly WebAppCapellaKM_05.Data.ApplicationDbContext _context;

        public DeleteModel(WebAppCapellaKM_05.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PubWork PubWork { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PubWork = await _context.PubWork.FirstOrDefaultAsync(m => m.PubWorkID == id);

            if (PubWork == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PubWork = await _context.PubWork.FindAsync(id);

            if (PubWork != null)
            {
                _context.PubWork.Remove(PubWork);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
