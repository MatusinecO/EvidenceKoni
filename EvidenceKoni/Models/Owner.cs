using System.ComponentModel.DataAnnotations;

namespace EvidenceKoni.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [Display(Name="Jméno")]
        public string Name { get; set; } = "";
        [Display(Name = "Příjmení")]
        public string Surname { get; set; } = "";
        [Display(Name = "Telefonní číslo")]
        public string Phone { get; set; } = "";
        [Display(Name = "Email")]
        public string Email { get; set; } = "";
        [Display(Name = "Adresa")]
        public string Adress { get; set; } = "";
        [Display(Name = "Město")]
        public string City { get; set; } = "";
        [Display(Name = "Celé jméno")]
        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }
        public ICollection<Stable>? Stables { get; set; }
        public ICollection<Horse>? Horses { get; set; }


    }
}
