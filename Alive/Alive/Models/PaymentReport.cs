using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Alive.Models
{
    public class PaymentReport
    {
        [Key]
        public Guid? Id { get; set; }
        public string? PatientName { get; set; }
        public int? DiscountAmount { get; set; }
        public int? Tax { get; set; }
        public int? SubTotal { get; set; }
        public int? GrandTotal { get; set; }
         public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


       

        public DateTime? CreatedDate { get; set; }

    }
}
