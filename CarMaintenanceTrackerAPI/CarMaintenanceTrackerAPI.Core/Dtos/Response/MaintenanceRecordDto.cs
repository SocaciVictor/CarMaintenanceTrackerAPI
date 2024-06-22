using CarMaintenanceTracker.Database.Entities;
using CarMaintenanceTracker.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Core.Dtos.Response
{
    public class MaintenanceRecordDto
    {
        public string? OwnerName { get; set; }
        public string? CarMake { get; set; }

        public string? CarModel { get; set; }

        public string? ServiceCenterName { get; set; }

        public string? MaintenanceType { get; set; }

        public DateTime Date { get; set; }

        public double Cost { get; set; }

        public string? Description { get; set; }

    }
}
