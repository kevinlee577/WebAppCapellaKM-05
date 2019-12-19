using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCapellaKM_05.Data;
using WebAppCapellaKM_05.Models;

namespace WebAppCapellaKM_05
{
    public class DetailsModel : PageModel
    {
        private readonly WebAppCapellaKM_05.Data.ApplicationDbContext _context;

        public DetailsModel(WebAppCapellaKM_05.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = await _context.Author.FirstOrDefaultAsync(m => m.AuthorID == id);

            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
