using CarMaintenanceTrackerAPI.Core.Dtos.Request;
using CarMaintenanceTrackerAPI.Core.Dtos.Response;
using CarMaintenanceTrackerAPI.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarMaintenanceTrackerAPI.Controllers
{
    [Route("api/ServicesCenters")]
    public class ServicesCentersController : BaseController
    {
        private readonly ServicesCentersServices _servicesCentersServices;

        public ServicesCentersController(ServicesCentersServices servicesCentersServices)
        {
            _servicesCentersServices = servicesCentersServices;
        }

        [HttpGet]
        [Route("GetServicesCenters")]
        [Authorize(Roles = "0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ServiceCenterDto>> GetServicesCenters()
        {
            var response = _servicesCentersServices.GetServiceCenterDtos();

            return response;
        }
        [HttpPost]
        [Route("AddServiceCenter")]
        [Authorize(Roles = "0")]
        public IActionResult AddService(AddServiceCenterRequest serviceCenterRequest)
        {
            _servicesCentersServices.AddServiceCenter(serviceCenterRequest);
            return Ok("Service added succesfully");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetServiceCenterOfOwner")]
        [Authorize(Roles = "0, 1")]
        public ActionResult<List<ServiceCenterDto>> GetServicesCentersOfOwner()
        {
            var authUserId = GetUserId();
            var response = _servicesCentersServices.GetServiceCenterDtosOfOwnner(authUserId);

            return response;
        }
    }
}
