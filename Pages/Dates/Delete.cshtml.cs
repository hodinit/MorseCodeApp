using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MorseCodeApp2.Data;
using MorseCodeApp2.Models;

namespace MorseCodeApp2.Pages.Dates
{
    public class DeleteModel : PageModel
    {
        private readonly MorseCodeApp2.Data.MorseCodeApp2Context _context;

        public DeleteModel(MorseCodeApp2.Data.MorseCodeApp2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Date Date { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var date = await _context.Date.FirstOrDefaultAsync(m => m.ID == id);

            if (date == null)
            {
                return NotFound();
            }
            else
            {
                Date = date;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var date = await _context.Date.FindAsync(id);
            if (date != null)
            {
                Date = date;
                _context.Date.Remove(Date);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
