using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MorseCodeApp2.Data;
using MorseCodeApp2.Models;

namespace MorseCodeApp2.Pages.MorseDefaultConversions
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly MorseCodeApp2.Data.MorseCodeApp2Context _context;

        public IndexModel(MorseCodeApp2.Data.MorseCodeApp2Context context)
        {
            _context = context;
        }

        public IList<MorseDefaultConversion> MorseDefaultConversion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            MorseDefaultConversion = await _context.MorseDefaultConversion
                .Include(m => m.User).ToListAsync();
        }
    }
}
