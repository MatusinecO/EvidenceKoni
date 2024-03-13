using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvidenceKoni.Models
{
    public enum Paid
    {
        Monthly, Weekly, Daily, Other
    }
    public class Stable
    {
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        //[Column(TypeName = "money")]
        [Display(Name ="Cena")]
        public decimal Price { get; set; }
        [Display(Name ="Frekvence plateb")]
        public Paid Paid { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Ustájen od")]
        public DateTime StabledFrom { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Ustájen do")]
        public DateTime StabledTo { get; set; }
        [Display(Name = "Poznámka")]
        public string Note { get; set; } = "";
        public int OwnerId { get; set; }
        public Owner? Owners { get; set; }


    }
}
