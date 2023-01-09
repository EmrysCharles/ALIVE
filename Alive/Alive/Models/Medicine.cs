using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class Medicine
    {
        [Key]
        public int? Sn { get; set; }
        public string? MedicineName { get; set; }
        public string? MedicineCategory { get; set; }
        public string? UnitPrice { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Edit { get; set; }
        public string? Delete { get; set; }


    }
}
