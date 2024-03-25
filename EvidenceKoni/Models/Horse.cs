using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EvidenceKoni.Models
{
    public enum Sex
    {
        [Display(Name = "Valach")]
        Gelding,
        [Display(Name = "Kobyla")]
        Mare,
        [Display(Name = "Hřebec")]
        Stalion,
        
    }
    public class Horse
    {
        public int Id { get; set; }
        [Display(Name ="Jméno koně")]
        public string Name { get; set; } = "";
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", 
            ApplyFormatInEditMode = true)]
        [Display(Name = "Datum narození")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Výžeh")]
        public string Burn { get; set; } = "";
        [Display(Name = "Čip")]
        public string Chip { get; set; } = "";
        [Display(Name = "Životní číslo")]
        public string LifeNumber { get; set; } = "";
        [Display(Name = "Číslo karty")]
        public string CardNumber { get; set; } = "";
        [Display(Name = "Plemeno")]
        public string Breed { get; set; } = "";
        [Display(Name = "Pohlaví")]
        public Sex Sex { get; set; }
        [Display(Name = "Barva")]
        public string Color { get; set; } = "";
        [Display(Name = "Popis")]
        public string Description { get; set; } = "";
        [Display(Name = "Poznámka")]
        public string Note { get; set; } = "";
        public int OwnerId { get; set; }
        public Owner? Owners { get; set; }
        public ICollection<Procedure>? Procedures { get; set; } = new List<Procedure>();
        //public ICollection<Procedure>? Procedures { get; set; }



    }
}
