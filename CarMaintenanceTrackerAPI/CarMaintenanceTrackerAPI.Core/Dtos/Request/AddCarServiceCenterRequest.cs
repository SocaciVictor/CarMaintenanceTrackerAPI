using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Core.Dtos.Request
{
    public class AddCarServiceCenterRequest
    {
        public int CarId { get; set; }
        public int ServiceCenterId { get; set; }
    }
}
