using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.InteropServices;

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
        [Required(ErrorMessage = "Zadejte jméno.")]
        public string Name { get; set; } = "";
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", 
            ApplyFormatInEditMode = true)]
        [Display(Name = "Datum narození")]
        [Required(ErrorMessage = "Zadejte datum narození.")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Výžeh")]
        [Required(ErrorMessage = "Zadejte číslo výžehu.")]
        public string Burn { get; set; } = "";
        [Display(Name = "Čip")]
        [Required(ErrorMessage = "Zadete ID čipu.")]
        public string Chip { get; set; } = "";
        [Display(Name = "Životní číslo")]
        [Required(ErrorMessage = "Zadejte životní číslo.")]
        public string LifeNumber { get; set; } = "";
        [Display(Name = "Číslo karty")]
        [Required(ErrorMessage = "Zadejte číslo karty.")]
        public string CardNumber { get; set; } = "";
        [Display(Name = "Plemeno")]
        [Required(ErrorMessage ="Zadejte plemeno.")]
        public string Breed { get; set; } = "";
        [Display(Name = "Pohlaví")]
        public Sex Sex { get; set; }
        [Display(Name = "Barva")]
        [Required(ErrorMessage ="Zadejte barvu.")]
        public string Color { get; set; } = "";
        [Display(Name = "Popis")]
        [Required(ErrorMessage = "Zadejte identifikační znaky z průkazu.")]
        public string Description { get; set; } = "";
        public int? OwnerId { get; set; }
        public Owner? Owners { get; set; }
        public ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();
    }
}
