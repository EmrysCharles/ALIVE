using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class Dispensary
    {

        [Key]
        public Guid? Id { get; set; }
        public string? Name{ get; set; }
        public string?Details{ get; set; }
        public string? Action { get; set; }
        public DateTime? CreatedDate{ get; set; }

    }
}
