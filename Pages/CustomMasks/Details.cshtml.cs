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
    public class DetailsModel : PageModel
    {
        private readonly MorseCodeApp2.Data.MorseCodeApp2Context _context;

        public DetailsModel(MorseCodeApp2.Data.MorseCodeApp2Context context)
        {
            _context = context;
        }

        public CustomMask CustomMask { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custommask = await _context.CustomMask
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (custommask == null)
            {
                return NotFound();
            }
            else
            {
                CustomMask = custommask;
            }
            return Page();
        }
    }
}
