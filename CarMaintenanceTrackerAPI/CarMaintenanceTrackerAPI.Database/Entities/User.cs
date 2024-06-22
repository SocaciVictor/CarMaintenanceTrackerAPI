using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTracker.Database.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Username { get; set; }

        [Required]
        [StringLength(256)]
        public string? Password { get; set; }

        [Required]
        [StringLength(256)]
        public string? PasswordSalt { get; set; }

        [Required]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [Range(0, 1, ErrorMessage = "Type must be either 0 (Administrator) or 1 (Simple user).")]
        public int Type { get; set; }

        public Car? Car { get; set; } // Relație one-to-one
    }
}
