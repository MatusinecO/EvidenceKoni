using System.ComponentModel.DataAnnotations;

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
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public Profession Profession { get; set; }
        public string Adress { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string Note { get; set; } = "";
        public ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();
    }
}

//smazat vazební tabulku ProcedureWorker. z ní přesunout do procedure tyto data a napojit do procedure workera

//Introducing FOREIGN KEY constraint 'FK_ProcedureWorker_Procedure_ProcedureId' on table 'ProcedureWorker' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
//Could not create constraint or index. See previous errors.