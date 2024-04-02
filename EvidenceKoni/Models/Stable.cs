using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvidenceKoni.Models
{
    public enum Paid
    {
        [Display(Name = "Mesíčně")]
        Monthly,
        [Display(Name = "Týdně")]
        Weekly,
        [Display(Name = "Denně")]
        Daily,
        [Display(Name = "jinak")]
        Other
    }
    public class Stable
    {
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name ="Cena")]
        [Required(ErrorMessage = "Zadejte cenu ustájení.")]
        public decimal Price { get; set; }
        [Display(Name ="Frekvence plateb")]
        public Paid Paid { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Ustájen od")]
        [Required(ErrorMessage = "Zadejte datum začátku ustájení.")]
        public DateTime StabledFrom { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Ustájen do")]
        [Required(ErrorMessage = "Zadejte datum konce ustájení.")]
        public DateTime StabledTo { get; set; }
        [Display(Name = "Poznámka")]
        [Required(ErrorMessage = "Popište typ a specifikaci ustájení.")]
        public string Note { get; set; } = "";
        public int OwnerId { get; set; }
        public Owner? Owners { get; set; }


    }
}
