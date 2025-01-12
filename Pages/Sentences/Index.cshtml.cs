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
    public class IndexModel : PageModel
    {
        private readonly MorseCodeApp2.Data.MorseCodeApp2Context _context;

        public IndexModel(MorseCodeApp2.Data.MorseCodeApp2Context context)
        {
            _context = context;
        }

        public IList<Sentence> Sentence { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Sentence = await _context.Sentence
                .Include(s => s.CustomMask)
                .Include(s => s.Date)
                .Include(s => s.MorseDefaultConversion)
                .Include(s => s.User).ToListAsync();
        }
    }
}
