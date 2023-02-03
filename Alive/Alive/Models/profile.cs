using Alive.ViewModel;

namespace Alive.Models
{
    public class profile :ApplicationUserViewModel
    { 
        public byte[]? ProfilePic { get; set; }
        public string? Address { get; set; }
        public string? Bio { get; set; }
    }
}
