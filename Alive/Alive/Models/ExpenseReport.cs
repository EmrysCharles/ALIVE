using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class ExpenseReport
    {
        [Key]
        public int? Id { get; set; }
        public string? ExpenseCategory { get; set; }
        public string? Amount { get; set; }
        public string? Description { get; set; }
       

        public DateTime? CreatedDate { get; set; }

    }
}
