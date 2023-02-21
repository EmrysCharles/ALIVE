using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using System.Data.SqlTypes;

namespace Alive.Models
{
    public class Payment
    {
        [Key]
        public Guid? Id { get; set; }

        public string? PatientName { get; set; }
        public int? Discount { get; set; }
        public string? PatientType { get; set; }
        public DateTime? PaymentDate { get; set; }

        public double? ConsultCharge { get; set; }
         public double? MedCharge { get; set; }
        public Byte? Proof { get; set; }
        public string? ModeOfPay { get; set; }
        public double? BedCharge { get; set; }
        public double? PaidAmount { get; set; }
        public string? PaymentReference { get; set; }
        public double? DueAmount { get; set; }
        public double? ChargedAmount { get; set; }

        public double? AccomodationCharge { get; set; }
        public double? LabCharge { get; set; }
        public bool? Deleted { get; set; }
        public string? Picture { get; set; }
        public string? Email { get; set; }

        //public IFormFile? ProofOfPayment { get; set; }
        //public string? ProofOfPaymentUrl { get; set; }
    }
}
