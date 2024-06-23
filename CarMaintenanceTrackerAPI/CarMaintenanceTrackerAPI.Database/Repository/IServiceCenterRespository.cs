using CarMaintenanceTracker.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Database.Repository
{
    public interface IServiceCenterRespository
    {
        List<ServiceCenter> GetAllServiceCenters();

        List<ServiceCenter> GetAllServiceCentersOfOwner(int authUserId);

        void AddServiceCenter(ServiceCenter serviceCenter);

        ServiceCenter GetServiceCenterById(int serviceId);
        bool ValidateServiceId(int serviceId);
    }
}
