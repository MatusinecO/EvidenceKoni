namespace EvidenceKoni.Models
{
    public enum Profession
    {
        Veterinarian,Farrier,Trainer,Other
    }
    public class Procedure
    {
        public int Id { get; set; }
        public Profession Profession { get; set; }
        public string Operation { get; set; } = "";
        public DateTime DateOfProcedure { get; set; }
        public decimal Price { get; set; }
        public string Note { get; set; } = "";
        public int HorseId { get; set; }
        public Horse? Horse { get; set; }
    }
}
