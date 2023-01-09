using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class BedAllotment
    {
        [Key]
        public Guid? Id { get; set; }
        public string? PatientName { get; set; }
        public string? BedCategory { get; set; }
        public string? BedNo { get; set; }
        public DateTime? AllotmentDate { get; set; }
        public DateTime? ReleasedDate { get; set; }


        public DateTime? CreatedDate { get; set; }
       
    }
}
