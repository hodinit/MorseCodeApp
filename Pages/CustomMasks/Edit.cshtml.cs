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

namespace MorseCodeApp2.Pages.CustomMasks
{
    public class EditModel : PageModel
    {
        private readonly MorseCodeApp2.Data.MorseCodeApp2Context _context;

        public EditModel(MorseCodeApp2.Data.MorseCodeApp2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomMask CustomMask { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custommask =  await _context.CustomMask.FirstOrDefaultAsync(m => m.ID == id);
            if (custommask == null)
            {
                return NotFound();
            }
            CustomMask = custommask;
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "ID", "Name");
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

            _context.Attach(CustomMask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomMaskExists(CustomMask.ID))
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

        private bool CustomMaskExists(int id)
        {
            return _context.CustomMask.Any(e => e.ID == id);
        }
    }
}
