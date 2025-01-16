using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MorseCodeApp2.Models;

namespace MorseCodeApp2.Data
{
    public class MorseCodeApp2Context : DbContext
    {
        public MorseCodeApp2Context (DbContextOptions<MorseCodeApp2Context> options)
            : base(options)
        {
        }

        public DbSet<MorseCodeApp2.Models.CustomMask> CustomMask { get; set; } = default!;
        public DbSet<MorseCodeApp2.Models.MorseDefaultConversion> MorseDefaultConversion { get; set; } = default!;
        public DbSet<MorseCodeApp2.Models.Sentence> Sentence { get; set; } = default!;
        public DbSet<MorseCodeApp2.Models.User> User { get; set; } = default!;
    }
}
