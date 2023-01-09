using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
    }
}
