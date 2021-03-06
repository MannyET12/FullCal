using System.ComponentModel.DataAnnotations;

namespace FullCal.Models
{
    public class Process
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Relational Data
        public virtual ICollection<Event> Events { get; set; }
    }
}
