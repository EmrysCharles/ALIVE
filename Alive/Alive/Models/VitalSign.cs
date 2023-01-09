using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Alive.Models
{
    public class VitalSign
    {
        [Key]
        public Guid Id { get; set; }
        public string? BodyTemperature { get; set; }
        public string? Height { get; set; }
        public string? BodyWeight { get; set; }
        public string? PulseRate { get; set; }
        public string? BloodSugar { get; set; }
        public string? BloodWeight { get; set; }
         public string? PainRate { get; set; }
        public string? LevelOfConsciousness { get; set; }
        public string? Skin { get; set; }
        public string? PupillaryAssesment { get; set; }
        public string? Delirium { get; set; }
     }
}
