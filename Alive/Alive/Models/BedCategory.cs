using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class BedCategory
    {
       [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
       
        public DateTime? CreatedDate { get; set; }

    }
}
