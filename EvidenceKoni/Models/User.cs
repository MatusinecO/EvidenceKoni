using System.ComponentModel.DataAnnotations;

namespace EvidenceKoni.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Jméno")]
        [Required(ErrorMessage ="Zadejte prosím jméno.")]
        public string FirstName { get; set; } = "";
        [Display(Name = "Příjmení")]
        [Required(ErrorMessage ="Zadejte prosím příjmení.")]
        public string LastName { get; set; } = "";
        [Display(Name ="Telefon")]
        [Phone(ErrorMessage = "Zadejte telefon ve formátu +XX-XXX-XXX-XXXX nebo XXX-XXXX-XXXX.")]
        [Required(ErrorMessage = "Zadejte prosím telefon.")]
        public string Phone { get; set; } = "";
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Nezadali jste platnou e-mailovou adresu.")]
        [Required(ErrorMessage = "Zadejte prosím e-mail.")]
        public string Email { get; set; } = "";
        [Display(Name = "Adresa")]
        [Required(ErrorMessage = "Zadejte prosím adresu.")]
        public string Adress { get; set; } = "";
        [Display(Name = "Město")]
        [Required(ErrorMessage = "Zadejte prosím město.")]
        public string City { get; set; } = "";
        [Display(Name ="Jméno")]
        public string FullName { get => $"{FirstName} {LastName}"; }

    }
}
