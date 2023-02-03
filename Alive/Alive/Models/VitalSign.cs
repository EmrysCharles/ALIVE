
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;

namespace Alive.Models
{
    public class VitalSign
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? VisitId { get; set; }

        public string? NurseName { get; set; }
          public string? BodyTemperature { get; set; }
        
        public string? Height { get; set; }
        
        public string? BodyWeight { get; set; }
        
        public string? PulseRate { get; set; }
        
        public string? BloodPressure { get; set; }
       
        public string? PainRate { get; set; }
        
        public string? LevelOfConsciousness { get; set; }
        public string? Skin { get; set; }
        public string? PupillaryAssesment { get; set; }
        public string? Comment { get; set; }
        
    }
}
