using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MorseCodeApp2.Data;
using MorseCodeApp2.Models;

namespace MorseCodeApp2.Pages.MorseDefaultConversions
{
    public class EditModel : PageModel
    {
        private readonly MorseCodeApp2.Data.MorseCodeApp2Context _context;

        public EditModel(MorseCodeApp2.Data.MorseCodeApp2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public MorseDefaultConversion MorseDefaultConversion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morsedefaultconversion =  await _context.MorseDefaultConversion.FirstOrDefaultAsync(m => m.ID == id);
            if (morsedefaultconversion == null)
            {
                return NotFound();
            }
            MorseDefaultConversion = morsedefaultconversion;
           ViewData["UserID"] = new SelectList(_context.Set<User>(), "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MorseDefaultConversion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MorseDefaultConversionExists(MorseDefaultConversion.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MorseDefaultConversionExists(int id)
        {
            return _context.MorseDefaultConversion.Any(e => e.ID == id);
        }
    }
}
