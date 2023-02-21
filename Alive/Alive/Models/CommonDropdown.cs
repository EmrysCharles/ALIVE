using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Alive.Models
{
    public class CommonDropdown : BaseModel
    {
        [Display(Name = "Drpdown Key")]
        public int DropdownKey { get; set; }

        
    }
}
