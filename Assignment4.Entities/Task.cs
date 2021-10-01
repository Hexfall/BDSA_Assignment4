using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment4.Entities
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public int? UserId { get; set; }
        public User AssignedTo { get; set; }
        public string Description { get; set; }
        [Required]
        public Core.State State { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
