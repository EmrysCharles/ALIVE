
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alive.Models
{
    public class MedicalHistory
    {
        [Key]
        public Guid Id { get; set; }

        public string? SexuallyActive { get; set; }
        public string? SexPreference { get; set; }
        public string? DrugTherapy { get; set; }
        public string? LastDose { get; set; }
        public string? DateTaken { get; set; }
        public string? Time { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateAdded { get; set; }
        public string? MedicalQuery { get; set; }
        public string? Diagnoses { get; set; }
        public string? Treatment { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }
    }
}
    

