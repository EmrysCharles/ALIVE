using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Alive.Models
{
    public class FamilyHistory
    {
        [Key]
        public string? CoronaryDisease { get; set; }
        public string? HeartDisease { get; set; }
        public string? Diabetes { get; set; }
        public string? HBP { get; set; }
        public string? HighCholesterol { get; set; }
        public string? Cancer { get; set; }
        public string? CancerType { get; set; }

        public string? SurgicalHistory { get; set; }
        public string? SurgeryType { get; set; }

        public string? Allergy { get; set; }

    }
}
