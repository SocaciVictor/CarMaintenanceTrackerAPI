using CarMaintenanceTracker.Database.Context;
using CarMaintenanceTracker.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarMaintenanceTrackerAPI.Database.Repository
{
    public class CarServiceCenterRepository : BaseRepository, ICarServiceCenter
    {
        public CarServiceCenterRepository(CarMaintenanceTrackerDbContext carMaintenanceTrackerDbContext) : base(carMaintenanceTrackerDbContext)
        {
        }

        public List<CarServiceCenter> GetAllCarServiceCenters()
        {
            var result = _carMaintenanceTrackerDbContext.CarServiceCenters
                .Include(c => c.Car)
                .Include(c => c.ServiceCenter)
                .ToList();
            return result;
        }
        public void AddCarServiceCenter(CarServiceCenter carServiceCenter)
        {
            _carMaintenanceTrackerDbContext.CarServiceCenters.Add(carServiceCenter);
            _carMaintenanceTrackerDbContext.SaveChanges();
        }
    }
}
