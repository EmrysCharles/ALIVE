using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class Medicine
    {
        [Key]
        public int? Id { get; set; }
        public string? MedicineName { get; set; }
        public string? MedicineCategory { get; set; }
        public double? Amount { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? unit { get; set; }
        public string? Delete { get; set; }
        public bool Deleted { get; set; }
    }
}
