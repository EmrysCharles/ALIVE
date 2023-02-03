using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Alive.Models
{
    public class PayCategory
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Unit { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Amountpaid { get; set; }


    }
}
