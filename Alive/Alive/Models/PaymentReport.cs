using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class PaymentReport
    {
        [Key]
        public Guid? Id { get; set; }
        public string? PatientName { get; set; }
        public string? DiscountAmount { get; set; }
        public string? Tax { get; set; }
        public string? SubTotal { get; set; }
        public string? GrandTotal { get; set; }
         public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


       

        public DateTime? CreatedDate { get; set; }

    }
}
