using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Core.Dtos.Request
{
    public class EditMaintenanceRecordRequest
    {

        public int CarId { get; set; }
        public int ServiceCenterId { get; set; }
        public int MaintenanceType { get; set; }
        public DateTime Date { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
    }
}
