﻿namespace EvidenceKoni.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string Adress { get; set; } = "";
        public string City { get; set; } = "";
        public ICollection<Stable>? Stables { get; set; }
        public ICollection<Horse>? Horses { get; set; }


    }
}
