using CarMaintenanceTracker.Database.Context;
using CarMaintenanceTracker.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Database.Repository
{
    public class ServiceCenterRepository : BaseRepository, IServiceCenterRespository
    {
        public ServiceCenterRepository(CarMaintenanceTrackerDbContext carMaintenanceTrackerDbContext) : base(carMaintenanceTrackerDbContext)
        {
        }

        public List<ServiceCenter> GetAllServiceCenters()
        {
            var result = _carMaintenanceTrackerDbContext.ServiceCenters
                .Include(sc => sc.CarServiceCenters)
                .Include(sc => sc.MaintenanceRecords)
                .ToList();
            return result;
        }

        public void AddServiceCenter(ServiceCenter serviceCenter)
        {
            _carMaintenanceTrackerDbContext.ServiceCenters.Add(serviceCenter);
            _carMaintenanceTrackerDbContext.SaveChanges();
        }
    }
}
