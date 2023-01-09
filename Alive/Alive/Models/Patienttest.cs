using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class Patienttest
    {
        [Key]
        public Guid Id { get; set; }
        public string? PatientName { get; set; }
        public string? VisitId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? TestDate { get; set; }
        public string? DateCreated { get; set; }
        public string? Edit { get; set; }
        public string? Delete { get; set; }


    }
}
