using System.ComponentModel.DataAnnotations;

namespace MorseCodeApp2.Models
{
    public class CustomMask
    {
        public int ID { get; set; }

        [RegularExpression(@"^[01]$", ErrorMessage = "Acest camp trebuie sa fie 0 sau 1")]
        [StringLength(1)]
        public string Character { get; set; }
        public string CustomEquivalent { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
    }
}
