using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class CheckupViewModel
    {
        public  List<Checkup>? Checkups { get; set; }
        public  Checkup? Checkup { get; set; }
        
        
    }
}

