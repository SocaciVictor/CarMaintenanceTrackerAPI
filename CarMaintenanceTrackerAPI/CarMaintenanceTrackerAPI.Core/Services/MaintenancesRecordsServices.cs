using CarMaintenanceTracker.Database.Entities;
using CarMaintenanceTracker.Database.Enums;
using CarMaintenanceTrackerAPI.Core.Dtos.Request;
using CarMaintenanceTrackerAPI.Core.Dtos.Response;
using CarMaintenanceTrackerAPI.Core.Mapping;
using CarMaintenanceTrackerAPI.Database.Repository;
using CarMaintenanceTrackerAPI.Infrastructure.Exceptions;
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
        private readonly ICarServiceCenter _carServiceCenterRepository;


       public MaintenancesRecordsServices(IMaintenanceRecordRepository maintenanceRecordRepository, ICarRepository carRepository, IServiceCenterRespository serviceCenterRespository, ICarServiceCenter carServiceCenter)
        {
            _maintenanceRecordRepository = maintenanceRecordRepository;
            _carRepository = carRepository;
            _serviceCenterRespository = serviceCenterRespository;
            _carServiceCenterRepository = carServiceCenter;
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
        public List<MaintenanceRecordDto> GetMaintenancesRecordOfOwner(int  ownerId)
        {
            var maitenances = _maintenanceRecordRepository.GetMaintenancesByOwnerId(ownerId);
            if (maitenances == null)
            {
                throw new ResourceMissingException("Owner has no car.");

            }
            List<MaintenanceRecordDto> maintenanceRecordDtos = new List<MaintenanceRecordDto>();

            foreach (MaintenanceRecord maintenanceRecord in maitenances)
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
                var carServiceCenter = new CarServiceCenter();
                carServiceCenter.CarId = result.CarId;
                carServiceCenter.ServiceCenterId = result.ServiceCenterId;
                _carServiceCenterRepository.AddCarServiceCenter(carServiceCenter);
                _maintenanceRecordRepository.AddMaintenanceRecord(result);
            }

        }
        public void EditMaintenanceRecord(EditMaintenanceRecordRequest request,int requestId)
        {
            var result = _maintenanceRecordRepository.GetMaintenanceById(requestId);

            if (result == null)
            {
                throw new ResourceMissingException($"Maintenance record with ID {requestId} was not found.");
            }

            if (ValidCarId(request.CarId)&& ValidServiceId(request.ServiceCenterId))
            {
                if (HasChangedCarId(request.CarId, result))
                {
                    _carServiceCenterRepository.EditCarId(request.CarId, result.CarId);
                }
                if(HasChangedServiceCenterId(request.ServiceCenterId, result))
                {
                    _carServiceCenterRepository.EditServiceId(request.ServiceCenterId, result.ServiceCenterId);
                }
                editTask(request, result);
                _maintenanceRecordRepository.EditMaintenance(result);

            }
        }
        public void DeleteMaintenanceRecord(int maintenanceId)
        {
          
            var maintenance = _maintenanceRecordRepository.GetMaintenanceById(maintenanceId);

           
            if (maintenance == null)
            {
                throw new ResourceMissingException($"Maintenance record with ID {maintenanceId} was not found.");
            }

            _maintenanceRecordRepository.DeleteMaintenance(maintenance);
        }

        private bool HasChangedCarId(int carId, MaintenanceRecord maintenanceRecord)
        {
            var car = _carRepository.GetCarById(carId);

            if(car == null)
            {
                throw new ResourceMissingException("Car not found");
            }

            if (maintenanceRecord.CarId == carId)
            {
                return false;
            }

            return true;
        }

        private bool HasChangedServiceCenterId(int serviceCenterId, MaintenanceRecord maintenanceRecord)
        {
            var serviceCenter = _serviceCenterRespository.GetServiceCenterById(serviceCenterId);
          

            if (serviceCenter == null)
            {
                throw new ResourceMissingException("Service center not found");
            }


            if (maintenanceRecord.ServiceCenterId == serviceCenterId)
            {
                return false;
            }

            return true;
        }

        private bool ValidCarId(int Id)
        {
            var car = _carRepository.ValidCarId(Id);

            if (car == false)
            {
                throw new ResourceMissingException("Car not found");
            }
            return true;
        }
        private bool ValidServiceId(int Id)
        {
            var service = _serviceCenterRespository.ValidateServiceId(Id);

            if (service == false)
            {
                throw new ResourceMissingException("Service not found");
            }
            return true;
        }
        private void editTask(EditMaintenanceRecordRequest request,MaintenanceRecord maintenanceRecord)
        {
            maintenanceRecord.CarId=request.CarId;
            maintenanceRecord.ServiceCenterId=request.ServiceCenterId;
            maintenanceRecord.Cost=request.Cost;
            maintenanceRecord.Date=request.Date;
            maintenanceRecord.Description=request.Description;
            maintenanceRecord.MaintenanceType = (MaintenanceType)request.MaintenanceType;
        }

    }
       
}

