using System.ComponentModel.DataAnnotations;

namespace CarMaintenanceTracker.Database.Entities
{
    public class ServiceCenter
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        // Relația cu MaintenanceRecord (one-to-many)
        public List<MaintenanceRecord> MaintenanceRecords { get; set; }

        // Relația cu CarServiceCenter (many-to-many)
        public List<CarServiceCenter> CarServiceCenters { get; set; }
    }
}