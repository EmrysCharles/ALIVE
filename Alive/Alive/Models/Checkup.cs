using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class Checkup
    {
        [Key]
        public Guid Id { get; set; }
        public string? VisitId { get; set; }

        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }
        public string? PatientType { get; set; }
        public DateTime? NextVisist { get; set; }
        public string? Advice { get; set; }
        public string? Comment { get; set; }
        
        public string? Diagnoses { get; set; }
        public string? Symptoms { get; set; }
        public string? HPI { get; set; }
        public string? PhysicalExamination { get; set; }

        public DateTime? DateCreated { get; set; }
        public string? Edit { get; set; }

    }
}
