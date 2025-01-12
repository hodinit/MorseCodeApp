namespace MorseCodeApp2.Models
{
    public class CustomMask
    {
        public int ID { get; set; }
        public string Character { get; set; }
        public string CustomEquivalent { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
    }
}
