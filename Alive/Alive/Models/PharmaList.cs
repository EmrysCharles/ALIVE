using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Alive.Models
{
    public class PharmaList
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? PharmaCategory { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
