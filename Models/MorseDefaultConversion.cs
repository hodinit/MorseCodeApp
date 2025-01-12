namespace MorseCodeApp2.Models
{
    public class MorseDefaultConversion
    {
        public int ID { get; set; }
        public string Character { get; set; }
        public string MorseEquivalent { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
    }
}
