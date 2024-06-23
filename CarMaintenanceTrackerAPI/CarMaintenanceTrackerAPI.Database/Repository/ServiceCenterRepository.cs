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
        public bool ValidateServiceId(int serviceId)
        {
            var result=_carMaintenanceTrackerDbContext.ServiceCenters
                .Any(x=>x.Id == serviceId);
            return result;
        }

        public List<ServiceCenter> GetAllServiceCentersOfOwner(int authUserId)
        {
            var result = _carMaintenanceTrackerDbContext.ServiceCenters?
                .Include(sc => sc.CarServiceCenters)
                .ThenInclude(sc => sc.Car)
                .ThenInclude(sc => sc.User)
                .Where(sc =>sc.Id == authUserId)
                .ToList();
            return result;
        }

        public ServiceCenter GetServiceCenterById(int serviceId)
        {
            var result = _carMaintenanceTrackerDbContext.ServiceCenters
               .Where(x => x.Id == serviceId)
               .FirstOrDefault();
            return result;
        }
    }
}
