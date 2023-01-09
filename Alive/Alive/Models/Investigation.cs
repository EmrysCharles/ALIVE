using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class Investigation
    {
        [Key]
        public int? Id { get; set; }
        public string? TestName { get; set; }
        public string? UnitPrice { get; set; }
         public string? Action { get; set; }

    }
}
