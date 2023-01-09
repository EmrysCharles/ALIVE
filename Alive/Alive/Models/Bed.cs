using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class Bed
    {
        [Key]
        public int? Id { get; set; }
        public string? BedCategoryName { get; set; }
        public string? BedNO { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Edit { get; set; }
        public string? Delete { get; set; }



    }
}
