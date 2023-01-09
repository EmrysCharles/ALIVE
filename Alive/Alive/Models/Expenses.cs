using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class Expenses
    {
        [Key]
        public string? ExpensesCategory { get; set; }
        public string? Amount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Action { get; set; }
    }
}
