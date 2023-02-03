using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Alive.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
         public int? GenderId { get; set; }

        [ForeignKey("GenderId")]
        public virtual CommonDropdown? Gender { get; set; }
    }
}
