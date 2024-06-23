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

        public void EditCarId(int carId, int oldCarId)
        {
            var carServiceCenter = _carMaintenanceTrackerDbContext.CarServiceCenters
                .FirstOrDefault(c => c.CarId == oldCarId);
            carServiceCenter.CarId = carId;
            _carMaintenanceTrackerDbContext.SaveChanges();
        }

        public void EditServiceId(int serviceCenterId, int oldServiceCenterId)
        {
            var carServiceCenter = _carMaintenanceTrackerDbContext.CarServiceCenters
                .FirstOrDefault(c => c.ServiceCenterId == oldServiceCenterId);
            carServiceCenter.ServiceCenterId = serviceCenterId;
            _carMaintenanceTrackerDbContext.SaveChanges();
        }
    }
}
