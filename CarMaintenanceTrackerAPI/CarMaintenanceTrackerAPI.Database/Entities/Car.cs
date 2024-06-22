using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTracker.Database.Entities
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Make { get; set; }

        [Required]
        [StringLength(50)]
        public string? Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [StringLength(10)]
        public string? LicensePlate { get; set; }

        public User? User { get; set; }
        public List<MaintenanceRecord>? MaintenanceRecords { get; set; }

        public List<CarServiceCenter>? CarServiceCenters { get; set; } // Relație many-to-many
    }
}
