using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace EvidenceKoni.Models
{
    public enum Profession
    {
        [Display(Name ="Veterinář")]
        Veterinary,
        [Display(Name ="Podkovář")]
        Farrier,
        [Display(Name ="Trenér")]
        Trainer,
        [Display(Name ="Jiné")]
        Other
    }
    public class Worker : User
    {
       
        [Display(Name = "Profese")]
        public Profession Profession { get; set; }
       
        public ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();
    }
}
