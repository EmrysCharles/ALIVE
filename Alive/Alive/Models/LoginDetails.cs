using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class LoginDetails
    {
        [Key]
        public Guid? Id { get; set; }
        public string? Email { get; set; }
          public DateTime? LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }


        public DateTime? Duration { get; set; }
        public string? CreatedDate { get; set; }
        public string? Action { get; set; }



    }
}
