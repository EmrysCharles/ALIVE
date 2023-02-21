using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class Treatment
    {
        [Key]
        public Guid? Id { get; set; }
        public string? Medicine { get; set; }
        public string? NOoFDays { get; set; }
        public bool? Deleted { get; set; }
        public double? amount { get; set; }
       
    }
}
