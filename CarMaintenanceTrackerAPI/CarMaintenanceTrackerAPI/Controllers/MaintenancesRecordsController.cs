using CarMaintenanceTrackerAPI.Core.Dtos.Request;
using CarMaintenanceTrackerAPI.Core.Dtos.Response;
using CarMaintenanceTrackerAPI.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarMaintenanceTrackerAPI.Controllers
{
    [Route("api/MaintenancesRecords")]
    public class MaintenancesRecordsController : BaseController
    {
        private MaintenancesRecordsServices _maintenancesRecordsServices { get; set; }

        public MaintenancesRecordsController(MaintenancesRecordsServices maintenancesRecordsServices)
        {
            _maintenancesRecordsServices = maintenancesRecordsServices;
        }

        [HttpGet]
        [Route("GetMaintenancesRecords")]
        [Authorize(Roles = "0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<MaintenanceRecordDto>> GetMaintenancesRecords()
        {
            var response = _maintenancesRecordsServices.GetMaintenanceDtos();

            return response;
        }
        [HttpPost]
        [Route("AddMaintenance")]
        [Authorize(Roles = "0")]
        public IActionResult AddMaintenance(AddMaintenanceRecordRequest maintenanceRequest)
        {
            _maintenancesRecordsServices.AddMaintenanceRecord(maintenanceRequest);
            return Ok("Maintenance added succesfully");
        }

        [HttpGet]
        [Route("GetMaintenanceOfOwner")]
        [Authorize(Roles = "0,1")]
        public ActionResult<List<MaintenanceRecordDto>> GetMaintenanceOfOwner()
        {
            var authUserId = GetUserId();
            var response = _maintenancesRecordsServices.GetMaintenancesRecordOfOwner(authUserId);

            return response;
        }
        [HttpPut]
        [Route("{maintenanceId}/edit-maintenance")]
        [Authorize(Roles = "0")]
        public IActionResult EditMaintenance([FromRoute] int maintenanceId, [FromBody] EditMaintenanceRecordRequest payload)
        {
            _maintenancesRecordsServices.EditMaintenanceRecord(payload,maintenanceId);
          

            return Ok("Maintenance has been successfully edited");
        }
        [HttpDelete]
        [Route("delete-maintenance")]
        [Authorize(Roles ="0")]
        public IActionResult DeleteMaintenance([FromQuery] int maintenanceId)
        {
            _maintenancesRecordsServices.DeleteMaintenanceRecord(maintenanceId);

            return Ok("Task has been successfully deleted");
        }
    }
}
