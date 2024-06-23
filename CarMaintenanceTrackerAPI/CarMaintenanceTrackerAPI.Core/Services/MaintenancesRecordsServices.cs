using CarMaintenanceTracker.Database.Entities;
using CarMaintenanceTrackerAPI.Core.Dtos.Request;
using CarMaintenanceTrackerAPI.Core.Dtos.Response;
using CarMaintenanceTrackerAPI.Core.Mapping;
using CarMaintenanceTrackerAPI.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Core.Services
{
    public class MaintenancesRecordsServices
    {
        private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;
        private readonly ICarRepository _carRepository;
        private readonly IServiceCenterRespository _serviceCenterRespository;


       public MaintenancesRecordsServices(IMaintenanceRecordRepository maintenanceRecordRepository, ICarRepository carRepository, IServiceCenterRespository serviceCenterRespository)
        {
            _maintenanceRecordRepository = maintenanceRecordRepository;
            _carRepository = carRepository;
            _serviceCenterRespository = serviceCenterRespository;
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
        public void AddMaintenanceRecord(AddMaintenanceRecordRequest request)
        {
            var result = request.ToEntity();
            if (ValidCarId(result.CarId) && ValidServiceId(result.ServiceCenterId))
            {
           
                _maintenanceRecordRepository.AddMaintenanceRecord(result);
            }

        }

        private bool ValidCarId(int Id)
        {
            var car = _carRepository.ValidCarId(Id);

            if (car == false)
            {
                throw new Exception("Car not found");
            }
            return true;
        }
        private bool ValidServiceId(int Id)
        {
            var service = _serviceCenterRespository.ValidateServiceId(Id);

            if (service == false)
            {
                throw new Exception("Service not found");
            }
            return true;
        }
    }
       
}

