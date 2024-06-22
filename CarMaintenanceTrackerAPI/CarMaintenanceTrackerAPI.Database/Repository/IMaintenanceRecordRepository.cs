using CarMaintenanceTracker.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Database.Repository
{
    public interface IMaintenanceRecordRepository
    {
        List<MaintenanceRecord> GetAllMaintenanceRecords();

        void AddMaintenanceRecord(MaintenanceRecord maintenanceRecord);
    }
}
