using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Alive.Models
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }

        public string? PatientName { get; set; }
        public string? Discount { get; set; }
        public string? SubTotal { get; set; }
        public DateTime? PaymentDate { get; set; }

        public string? GrandTotal { get; set; }
         public string? CommonCharge { get; set; }
        public string? Tax { get; set; }
        public string? ModeOfPayment { get; set; }
        public string? Currency { get; set; }
        public string? PaidAmount { get; set; }
        public string? PaymentReference { get; set; }
        public string? DueAmount { get; set; }
        public string? ChargedAmount { get; set; }

        public string? Edit { get; set; }
        public string? Delete { get; set; }



    }
}
