using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Alive.Models
{
    public class DocInfo
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public string? Email { get; set; }
        public string? NurseId { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Category { get; set; }
        public string? Qualifications { get; set; }

        public DateTime? DateCreated { get; set; }
        public string? Edit { get; set; }
    }
}
