using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class ExpensesCategory
    {
        [Key]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Action { get; set; }
        
    }
}
