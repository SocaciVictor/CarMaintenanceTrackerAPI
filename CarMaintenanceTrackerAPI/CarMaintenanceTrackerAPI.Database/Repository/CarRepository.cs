using CarMaintenanceTracker.Database.Context;
using CarMaintenanceTracker.Database.Entities;
using CarMaintenanceTrackerAPI.Infrastructure.Exceptions;
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
        public void EditCar(Car car)
        {
            if (_carMaintenanceTrackerDbContext.Entry(car).State == EntityState.Modified)
                SaveChanges();
        }
        public Car GetCarById(int carId)
        {
           var result= _carMaintenanceTrackerDbContext.Cars.
                Include(c => c.User).
                Where(c=>c.Id == carId).
                FirstOrDefault();
            if (result == null)
                throw new ResourceMissingException("Car doesn't exist");
            return result;
        }
        public bool ValidCarId(int carId)
        {
            var result=_carMaintenanceTrackerDbContext.Cars
                .Any(x => x.Id == carId);
            return result;

        }
    }
}
