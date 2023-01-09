using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class PayCategory
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Unit { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Action { get; set; }


    }
}
