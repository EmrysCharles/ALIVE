using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Alive.Models
{
    public class SocialHistory
    {
        [Key]
        public string? Occupation { get; set; }
        public string? Smoking { get; set; }
        public string? DrugUse { get; set; }
        public string? Addiction { get; set; }
        public string? SexuallyActive { get; set; }
        public string? UnproctectedSex { get; set; }
        public string? When { get; set; }
        public string? MSM { get; set; }
        public string? MilitaryService { get; set; }





    }
}
