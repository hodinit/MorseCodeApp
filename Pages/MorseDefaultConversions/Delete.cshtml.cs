using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MorseCodeApp2.Data;
using MorseCodeApp2.Models;

namespace MorseCodeApp2.Pages.MorseDefaultConversions
{
    public class DeleteModel : PageModel
    {
        private readonly MorseCodeApp2.Data.MorseCodeApp2Context _context;

        public DeleteModel(MorseCodeApp2.Data.MorseCodeApp2Context context)
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

            var morsedefaultconversion = await _context.MorseDefaultConversion.FirstOrDefaultAsync(m => m.ID == id);

            if (morsedefaultconversion == null)
            {
                return NotFound();
            }
            else
            {
                MorseDefaultConversion = morsedefaultconversion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morsedefaultconversion = await _context.MorseDefaultConversion.FindAsync(id);
            if (morsedefaultconversion != null)
            {
                MorseDefaultConversion = morsedefaultconversion;
                _context.MorseDefaultConversion.Remove(MorseDefaultConversion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
