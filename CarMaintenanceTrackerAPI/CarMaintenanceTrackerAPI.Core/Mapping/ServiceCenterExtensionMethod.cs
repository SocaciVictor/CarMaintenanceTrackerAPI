using CarMaintenanceTracker.Database.Entities;
using CarMaintenanceTrackerAPI.Core.Dtos.Request;
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
        public static ServiceCenter ToEntity(this AddServiceCenterRequest addServiceCenter)
        {
            if (addServiceCenter == null) return null;

            var result = new ServiceCenter();

            result.Name = addServiceCenter.Name;
            result.Address = addServiceCenter.Address;
            result.Phone = addServiceCenter.Phone;
            result.Email = addServiceCenter.Email;

            return result;
        }
    }
}
