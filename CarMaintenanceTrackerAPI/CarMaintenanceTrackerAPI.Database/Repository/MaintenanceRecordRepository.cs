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
    public class MaintenanceRecordRepository : BaseRepository, IMaintenanceRecordRepository
    {
        public MaintenanceRecordRepository(CarMaintenanceTrackerDbContext carMaintenanceTrackerDbContext) : base(carMaintenanceTrackerDbContext)
        {
        }

        public List<MaintenanceRecord> GetAllMaintenanceRecords() {
           
            var result = _carMaintenanceTrackerDbContext.MaintenanceRecords
                .Include(m => m.Car)
                .ThenInclude(m => m.User)
                .Include(m => m.ServiceCenter)
                .ToList();
            return result;
        }

        public void AddMaintenanceRecord(MaintenanceRecord maintenanceRecord)
        {
            _carMaintenanceTrackerDbContext.MaintenanceRecords.Add(maintenanceRecord);
            _carMaintenanceTrackerDbContext.SaveChanges();
        }
        public void EditMaintenance(MaintenanceRecord maintenanceRecord)
        {
            if (_carMaintenanceTrackerDbContext.Entry(maintenanceRecord).State == EntityState.Modified)
                SaveChanges();
        }
        public MaintenanceRecord GetMaintenanceById(int Id)
        {
            var result = _carMaintenanceTrackerDbContext.MaintenanceRecords
                .Include(c => c.Car)
                .Include(c => c.ServiceCenter)
                .Where(c => c.Id == Id)
                .FirstOrDefault();
            if (result == null)
               throw new ResourceMissingException("Maintenance doesn't exist.");
            return result;

            
        }
        public List<MaintenanceRecord> GetMaintenancesByOwnerId(int Id)
        {
            var result = _carMaintenanceTrackerDbContext.MaintenanceRecords
                .Include(c => c.Car)
                .ThenInclude(c=>c.User)
                .Include(c => c.ServiceCenter)
                .Where(c => c.Car.UserId == Id)
                .ToList();
            if (result == null)
                throw new ResourceMissingException("Maintenance doesn't exist.");
            return result;

        }
        public void DeleteMaintenance(MaintenanceRecord maintenance)
        {
          
            if(maintenance != null)
            {
                _carMaintenanceTrackerDbContext.Remove(maintenance);
                _carMaintenanceTrackerDbContext.SaveChanges();
            }    

        }
    }
}
