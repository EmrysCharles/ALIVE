using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class LabTestFormViewModel
    {
        [Key]
        public int? Id { get; set; }

        public string? LabTestName { get; set; }
        public string? TestCategory { get; set; }
        public double? UnitPrice { get; set; }
        public string? ReferenceRange { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
