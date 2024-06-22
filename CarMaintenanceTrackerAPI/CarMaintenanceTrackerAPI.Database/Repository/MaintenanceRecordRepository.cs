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
    public class MaintenanceRecordRepository : BaseRepository, IMaintenanceRecordRepository
    {
        public MaintenanceRecordRepository(CarMaintenanceTrackerDbContext carMaintenanceTrackerDbContext) : base(carMaintenanceTrackerDbContext)
        {
        }

        public List<MaintenanceRecord> GetAllMaintenanceRecords() {
           
            var result = _carMaintenanceTrackerDbContext.MaintenanceRecords
                .Include(m => m.Car)
                .Include(m => m.ServiceCenter)
                .ToList();
            return result;
        }

        public void AddMaintenanceRecord(MaintenanceRecord maintenanceRecord)
        {
            _carMaintenanceTrackerDbContext.MaintenanceRecords.Add(maintenanceRecord);
            _carMaintenanceTrackerDbContext.SaveChanges();
        }
    }
}
