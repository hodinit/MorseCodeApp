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

namespace MorseCodeApp2.Pages.Sentences
{
    public class EditModel : PageModel
    {
        private readonly MorseCodeApp2.Data.MorseCodeApp2Context _context;

        public EditModel(MorseCodeApp2.Data.MorseCodeApp2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Sentence Sentence { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sentence =  await _context.Sentence.FirstOrDefaultAsync(m => m.ID == id);
            if (sentence == null)
            {
                return NotFound();
            }
            Sentence = sentence;
           ViewData["CustomMaskID"] = new SelectList(_context.CustomMask, "ID", "ID");
           ViewData["DateID"] = new SelectList(_context.Date, "ID", "ID");
           ViewData["MorseDefaultConversionID"] = new SelectList(_context.MorseDefaultConversion, "ID", "ID");
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

            _context.Attach(Sentence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SentenceExists(Sentence.ID))
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

        private bool SentenceExists(int id)
        {
            return _context.Sentence.Any(e => e.ID == id);
        }
    }
}
