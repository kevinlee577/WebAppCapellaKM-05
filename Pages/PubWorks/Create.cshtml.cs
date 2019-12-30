using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppCapellaKM_05.Data;
using WebAppCapellaKM_05.Models;

namespace WebAppCapellaKM_05.Pages.PubWorks
{
//    public class CreateModel : PageModel
    public class CreateModel : PublicationNamePageModel
    {
        private readonly WebAppCapellaKM_05.Data.ApplicationDbContext _context;

        public CreateModel(WebAppCapellaKM_05.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulatePublicationsDropDownList(_context);
            PopulateAuthorsDropDownList(_context);

            return Page();
        }

        [BindProperty]
        public PubWork PubWork { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                    {
                        return Page();
                    }

                //    _context.PubWork.Add(PubWork);
                //    await _context.SaveChangesAsync();

                //    return RedirectToPage("./Index");

            var emptyPubWork = new PubWork();

            if (await TryUpdateModelAsync<PubWork>(
                 emptyPubWork,
                 "PubWork",   // Prefix for form value.
                 s => s.PubWorkKeyID, s => s.PubWorkName, s => s.PubWorkYear, s => s.AuthorID, s => s.PublicationID, s => s.PubWorkNotes, s => s.PubWorkAbstract, s => s.PubWorkKeywords))
            {
                _context.PubWork.Add(emptyPubWork);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }   

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulatePublicationsDropDownList(_context, emptyPubWork.PublicationID);
            PopulateAuthorsDropDownList(_context, emptyPubWork.AuthorID);

            return Page();

        }

     }
}

