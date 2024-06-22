

using CarMaintenanceTracker.Database.Context;

namespace CarMaintenanceTrackerAPI.Database.Repository
{
    public class BaseRepository
    {
        protected CarMaintenanceTrackerDbContext _carMaintenanceTrackerDbContext { get; set; }

        public BaseRepository(CarMaintenanceTrackerDbContext carMaintenanceTrackerDbContext)
        {
            _carMaintenanceTrackerDbContext = carMaintenanceTrackerDbContext;
        }
    
        public void SaveChanges()
        {
            _carMaintenanceTrackerDbContext.SaveChanges();
        }
    
    }
}
