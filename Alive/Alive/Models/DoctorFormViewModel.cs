using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class DoctorFormViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public string? Email { get; set; }
        public string? DoctorId { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Category { get; set; }
        public string? Qualifications { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }

        public DateTime? DateCreated { get; set; }
        public string? Edit { get; set; }
    }
}
