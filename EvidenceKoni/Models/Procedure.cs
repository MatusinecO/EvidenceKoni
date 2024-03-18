using System.ComponentModel.DataAnnotations;

namespace EvidenceKoni.Models
{
    public class Procedure
    {
        public int Id { get; set; }
        [Display(Name = "Popis zákroku")]
        public string Operation { get; set; } = "";
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Datum zákroku")]
        public DateTime DateOfProcedure { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name ="Cena za zákrok")]
        public decimal Price { get; set; }
        [Display(Name ="Poznámka")]
        public string Note { get; set; } = "";
        public int? HorseId { get; set; }
        public Horse? Horse { get; set; }
        public int? WorkerId { get; set; }
        public Worker? Worker { get; set; }

    }
}
