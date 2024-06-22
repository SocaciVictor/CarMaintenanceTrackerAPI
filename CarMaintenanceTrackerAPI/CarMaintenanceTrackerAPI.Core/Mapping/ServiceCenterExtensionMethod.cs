using CarMaintenanceTracker.Database.Entities;
using CarMaintenanceTrackerAPI.Core.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Core.Mapping
{
    public static class ServiceCenterExtensionMethod
    {
        public static ServiceCenterDto ToServiceCenterDto(this ServiceCenter serviceCenter)
        {
            var result = new ServiceCenterDto();

            result.Name = serviceCenter.Name;
            result.Address = serviceCenter.Address;
            result.Phone = serviceCenter.Phone;
            result.Email = serviceCenter.Email;

            return result;
        }
    }
}
