namespace EvidenceKoni.Models
{
    public enum Paid
    {
        Monthly, Weekly, Daily, Other
    }
    public class Stable
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public Paid Paid { get; set; }
        public DateTime StabledFrom { get; set; }
        public DateTime StabledTo { get; set; }
        public string Note { get; set; } = "";
        public int OwnerId { get; set; }
        public Owner? Owners { get; set; }


    }
}
