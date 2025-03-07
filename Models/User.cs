using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;

namespace MorseCodeApp2.Models
{
    public class User
    {
        public int ID { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? Admin { get; set; }

        public List<Sentence> Sentences { get; set; }
        public List<CustomMask> CustomMasks { get; set; }

    }
}
