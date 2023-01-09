using Microsoft.Build.Framework;

namespace Alive.ViewModel
{
    public class ApplicationUserViewModel
    {
        [Required]
        public string? FirstName { get; set;}
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? Gender { get; set; }

        public string? Email { get; set;}
        public string? Password { get; set;}
        public string? PhoneNumber { get; set;}   
        public string? ConfirmPassword{ get; set;}    
    }
}
