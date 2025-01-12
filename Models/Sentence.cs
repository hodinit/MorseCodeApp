namespace MorseCodeApp2.Models
{
    public class Sentence
    {
        public int ID { get; set; }
        public string Input { get; set; }
        public string? Output { get; set; }

        public int? UserID { get; set; }
        public User? User { get; set; }

        public int? MorseDefaultConversionID { get; set; }
        public MorseDefaultConversion? MorseDefaultConversion { get; set; }

        public int? CustomMaskID { get; set; }
        public CustomMask? CustomMask { get; set; }

        public int? DateID { get; set; }
        public Date? Date { get; set; }

    }
}
