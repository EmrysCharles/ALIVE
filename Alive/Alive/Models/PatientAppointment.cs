
using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class PatientAppointment
    {
        [Key]
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public string? DoctorName { get; set; }
         public int? SerialNumber { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? AppointmentTime { get; set; }
        public string? PatientType { get; set; }
        public string? Edit { get; set; }
        public string? Delete { get; set; }

        public DateTime? DateCreated { get; set; }

    }
}
