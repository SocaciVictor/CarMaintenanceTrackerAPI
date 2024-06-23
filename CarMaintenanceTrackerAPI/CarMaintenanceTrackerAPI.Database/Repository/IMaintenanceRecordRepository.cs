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

        void EditMaintenance(MaintenanceRecord maintenanceRecord);

        void DeleteMaintenance(MaintenanceRecord maintenance);

        MaintenanceRecord GetMaintenanceById(int Id);
        List<MaintenanceRecord> GetMaintenancesByOwnerId(int Id);
    }
}
