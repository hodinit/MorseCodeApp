using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MorseCodeApp2.Data;
using MorseCodeApp2.Models;

namespace MorseCodeApp2.Pages.Sentences
{
    public class DetailsModel : PageModel
    {
        private readonly MorseCodeApp2.Data.MorseCodeApp2Context _context;

        public DetailsModel(MorseCodeApp2.Data.MorseCodeApp2Context context)
        {
            _context = context;
        }

        public Sentence Sentence { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sentence = await _context.Sentence
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sentence == null)
            {
                return NotFound();
            }
            else
            {
                Sentence = sentence;
            }
            return Page();
        }
    }
}
