using CarMaintenanceTracker.Database.Entities;
using CarMaintenanceTrackerAPI.Core.Dtos.Response;
using CarMaintenanceTrackerAPI.Core.Mapping;
using CarMaintenanceTrackerAPI.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Core.Services
{
    public class MaintenancesRecordsServices
    {
        private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;

        public MaintenancesRecordsServices(IMaintenanceRecordRepository maintenanceRecordRepository)
        {
            _maintenanceRecordRepository = maintenanceRecordRepository;
        }

        public List<MaintenanceRecordDto> GetMaintenanceDtos()
        {
            var maintenanceRecords = _maintenanceRecordRepository.GetAllMaintenanceRecords();

            List<MaintenanceRecordDto> maintenanceRecordDtos = new List<MaintenanceRecordDto>();

            foreach (MaintenanceRecord maintenanceRecord in maintenanceRecords)
            {
                maintenanceRecordDtos.Add(maintenanceRecord.ToMaintenanceRecordDto());
            }

            return maintenanceRecordDtos;
        }
    }
}
