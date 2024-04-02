using System.ComponentModel.DataAnnotations;

namespace EvidenceKoni.Models
{
    public class Procedure
    {
        public int Id { get; set; }
        [Display(Name = "Popis zákroku")]
        [Required(ErrorMessage = "Popište obsah zákroku.")]
        public string Operation { get; set; } = "";
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Datum zákroku")]
        [Required(ErrorMessage = "Vyplňte datum zákroku.")]
        public DateTime DateOfProcedure { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name ="Cena za zákrok")]
        [Required(ErrorMessage = "Zadejte cenu zákroku.")]
        public decimal Price { get; set; }
        public int? HorseId { get; set; }
        public Horse? Horse { get; set; }
        public int? WorkerId { get; set; }
        public Worker? Worker { get; set; }

    }
}
