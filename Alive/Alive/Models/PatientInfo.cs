using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class PatientInfo
    {
        [Key]
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? MaritalStatus { get; set; }
        public string? Gender { get; set; }
        public string? Nok { get; set; }
        public string? Bloodgroup { get; set; }
        public string? Genotype { get; set; }
        public DateTime? BOB { get; set; }
        public string? NewCheckup { get; set; }
        public string? Edit { get; set; }
        public string? Delete { get; set; }



    }
}
