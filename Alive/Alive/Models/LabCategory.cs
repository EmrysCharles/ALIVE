using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class LabCategory
    {
        [Key]
        public int? sn { get; set; }
        public string? LabName { get; set; }
        public string? Description { get; set; }
        public string? DateCreated { get; set; }
        public string? Edit { get; set; }
        public string? Details { get; set; }
        public string? Delete { get; set; }


    }
}
