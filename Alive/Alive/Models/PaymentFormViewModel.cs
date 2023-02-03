using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class PaymentFormViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string? PatientName { get; set; }
        public int? Discount { get; set; }
        public string? PatientType { get; set; }
        public DateTime? PaymentDate { get; set; }

        public double? ConsultCharge { get; set; }
        public double? MedCharge { get; set; }
        public byte? Proof { get; set; }
        public string? ModeOfPay { get; set; }
        public double? BedCharge { get; set; }
        public double? PaidAmount { get; set; }
        public string? PaymentReference { get; set; }
        public double? DueAmount { get; set; }
        public double? ChargedAmount { get; set; }

        public double? AccomodationCharge { get; set; }
        public double? LabCharge { get; set; }
        public string? Picture { get; set; }
        public string? Email { get; set; }

        //public IFormFile? ProofOfPayment { get; set; }
        //public string? ProofOfPaymentUrl { get; set; }

    }
}
