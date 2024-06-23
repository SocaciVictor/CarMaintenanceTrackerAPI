using CarMaintenanceTracker.Database.Entities;
using CarMaintenanceTrackerAPI.Core.Dtos.Request;
using CarMaintenanceTrackerAPI.Core.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Core.Mapping
{
    public static class MaintenanceRecordExtensionMethod
    {
        public static MaintenanceRecordDto ToMaintenanceRecordDto(this MaintenanceRecord maintenanceRecord)
        {
            var result = new MaintenanceRecordDto();

            result.OwnerName = maintenanceRecord.Car.User.FirstName + " " + maintenanceRecord.Car.User.LastName;
            result.CarMake = maintenanceRecord.Car.Make;
            result.CarModel = maintenanceRecord.Car.Model;
            result.ServiceCenterName = maintenanceRecord.ServiceCenter.Name;
            result.MaintenanceType = maintenanceRecord.MaintenanceType.ToString();
            result.Date = maintenanceRecord.Date;
            result.Cost = maintenanceRecord.Cost;
            result.Description = maintenanceRecord.Description;

            return result;
        }
        public static MaintenanceRecord ToEntity(this AddMaintenanceRecordRequest addMaintenance)
        {
            if (addMaintenance == null) return null;

            var result = new MaintenanceRecord();

            result.CarId = addMaintenance.CarId;
            result.ServiceCenterId = addMaintenance.ServiceCenterId;
            result.Cost=addMaintenance.Cost;
            result.Description = addMaintenance.Description;
            result.Date=addMaintenance.Date;
            return result;
        }
    }
}
