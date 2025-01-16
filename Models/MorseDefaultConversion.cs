using System.ComponentModel.DataAnnotations;

namespace MorseCodeApp2.Models
{
    public class MorseDefaultConversion
    {
        public int ID { get; set; }

        [RegularExpression(@"^[a-z]$", ErrorMessage = "Acest camp trebuie sa fie o litera lowercase")]
        [StringLength(1)]
        public string Character { get; set; }

        [RegularExpression(@"^[01]+$", ErrorMessage = "Acest camp trebuie sa fie doar 1 sau 0 sau combinatii intre ele")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Acest camp trebuie sa aiba de la 1 pana la 5 valori")]
        public string MorseEquivalent { get; set; }
        
    }
}
