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
    public class CarRepository : BaseRepository, ICarRepository
    {
        public CarRepository(CarMaintenanceTrackerDbContext carMaintenanceTrackerDbContext) : base(carMaintenanceTrackerDbContext)
        {
        }

        public List<Car> GetAllCars()
        {
            var result = _carMaintenanceTrackerDbContext.Cars
                .Include(c => c.User)
                .Include(c => c.MaintenanceRecords)
                .Include(c => c.CarServiceCenters)  
                .ToList();
            return result;
        }

        public void AddCar(Car car)
        {
            _carMaintenanceTrackerDbContext.Cars.Add(car);
            _carMaintenanceTrackerDbContext.SaveChanges();
        }
        public bool ValidCarId(int carId)
        {
            var result=_carMaintenanceTrackerDbContext.Cars
                .Any(x => x.Id == carId);
            return result;

        }
    }
}
