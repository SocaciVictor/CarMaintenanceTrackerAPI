using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMaintenanceTracker.Database.Enums;

namespace CarMaintenanceTracker.Database.Entities
{
    public class MaintenanceRecord
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public MaintenanceType MaintenanceType { get; set; }

        [Required]
        public int ServiceCenterId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Relația cu Car (one-to-many)
        public Car Car { get; set; }

        // Relația cu ServiceCenter (many-to-one)
        public ServiceCenter ServiceCenter { get; set; }
    }
}
