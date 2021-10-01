using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment4.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}
