using System.ComponentModel.DataAnnotations;

namespace EvidenceKoni.Models
{
    public class Owner : User
    {
       
        public ICollection<Stable>? Stables { get; set; }
        public ICollection<Horse>? Horses { get; set; }

    }
}
