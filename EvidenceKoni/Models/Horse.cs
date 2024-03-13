using Microsoft.EntityFrameworkCore.Metadata;
using System.Globalization;

namespace EvidenceKoni.Models
{
    public enum Sex
    {
        Mare,Gelding,Stallion,Foal
    }
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public string Burn { get; set; } = "";
        public string Chip { get; set; } = "";
        public string LifeNumber { get; set; } = "";
        public string CardNumber { get; set; } = "";
        public string Breed { get; set; } = "";
        public Sex Sex { get; set; }
        public string Color { get; set; } = "";
        public string Description { get; set; } = "";
        public string Note { get; set; } = "";
        public int OwnerId { get; set; }
        public Owner? Owners { get; set; }
        public ICollection<Procedure>? Procedures { get; set; }




    }
}
