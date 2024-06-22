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
                .ToList();
            return result;
        }
    }
}
