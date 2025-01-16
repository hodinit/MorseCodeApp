using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MorseCodeApp2.Data;
using MorseCodeApp2.Models;

namespace MorseCodeApp2.Pages.Sentences
{
    public class CreateModel : PageModel
    {
        private readonly MorseCodeApp2.Data.MorseCodeApp2Context _context;

        public CreateModel(MorseCodeApp2.Data.MorseCodeApp2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomMaskID"] = new SelectList(_context.CustomMask, "ID", "ID");
        ViewData["MorseDefaultConversionID"] = new SelectList(_context.MorseDefaultConversion, "ID", "ID");
        ViewData["UserID"] = new SelectList(_context.Set<User>(), "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Sentence Sentence { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sentence.Add(Sentence);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
