using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Alive.Models
{
    public class Drug
    {
        [Key]
        
        public string? Name { get; set; }
        public string? DrugCategory { get; set; }
        public string? DateCreated { get; set; }
        public string? Comment { get; set; }

    }
}
