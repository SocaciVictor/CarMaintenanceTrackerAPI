using CarMaintenanceTrackerAPI.Core.Dtos.Request;
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
        [HttpPost]
        [Route("AddServiceCenter")]
        public IActionResult AddService(AddServiceCenterRequest serviceCenterRequest)
        {
            _servicesCentersServices.AddServiceCenter(serviceCenterRequest);
            return Ok("Service added succesfully");
        }
    }
}
