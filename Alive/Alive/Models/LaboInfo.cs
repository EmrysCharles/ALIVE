using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class LaboInfo
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? LaboratorianId { get; set; }
         public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public string? Category { get; set; }
        public DateTime? Qualification { get; set; }
       
        public DateTime? CreatedDate { get; set; }
        public string? Action { get; set; }

    }
}
