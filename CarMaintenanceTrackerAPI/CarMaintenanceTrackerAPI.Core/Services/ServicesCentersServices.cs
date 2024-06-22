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
    public class ServicesCentersServices
    {
        private readonly IServiceCenterRespository _servicesCenterRepository;

        public ServicesCentersServices(IServiceCenterRespository serviceCenterRespository)
        {
            _servicesCenterRepository = serviceCenterRespository;
        }

        public List<ServiceCenterDto> GetServiceCenterDtos()
        {
            var serviceCenters = _servicesCenterRepository.GetAllServiceCenters();

            List<ServiceCenterDto> serviceCenterDtos = new List<ServiceCenterDto>();

            foreach (ServiceCenter serviceCenter in serviceCenters)
            {
                serviceCenterDtos.Add(serviceCenter.ToServiceCenterDto());
            }

            return serviceCenterDtos;
        }
    }
}
