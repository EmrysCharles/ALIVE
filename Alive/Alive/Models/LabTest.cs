using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Alive.Models
{
    public class LabTest
    {
        [Key]
        public int? Id { get; set; }

        public string? LabTestName { get; set; }
        public string? TestCategory { get; set; }
        public string? Unit { get; set; }
        public string? UnitPrice { get; set; }
        public string? ReferenceRange { get; set; }

        public DateTime? DateCreated { get; set; }
        public string? Edit { get; set; }
        public string? Delete { get; set; }

    }
}
