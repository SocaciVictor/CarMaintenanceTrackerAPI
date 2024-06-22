using CarMaintenanceTrackerAPI.Core.Dtos.Response;
using CarMaintenanceTrackerAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarMaintenanceTrackerAPI.Controllers
{
    [Route("api/ServicesCenters")]
    public class ServicesCentersController : Controller
    {
        private readonly ServicesCentersServices _servicesCentersServices;

        public ServicesCentersController(ServicesCentersServices servicesCentersServices)
        {
            _servicesCentersServices = servicesCentersServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ServiceCenterDto>> GetServicesCenters()
        {
            var response = _servicesCentersServices.GetServiceCenterDtos();

            return response;
        }
    }
}
