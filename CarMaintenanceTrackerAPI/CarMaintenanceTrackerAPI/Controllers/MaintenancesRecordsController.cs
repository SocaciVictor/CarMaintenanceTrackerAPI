using CarMaintenanceTrackerAPI.Core.Dtos.Request;
using CarMaintenanceTrackerAPI.Core.Dtos.Response;
using CarMaintenanceTrackerAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarMaintenanceTrackerAPI.Controllers
{
    [Route("api/MaintenancesRecords")]
    public class MaintenancesRecordsController : Controller
    {
        private MaintenancesRecordsServices _maintenancesRecordsServices { get; set; }

        public MaintenancesRecordsController(MaintenancesRecordsServices maintenancesRecordsServices)
        {
            _maintenancesRecordsServices = maintenancesRecordsServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<MaintenanceRecordDto>> GetMaintenancesRecords()
        {
            var response = _maintenancesRecordsServices.GetMaintenanceDtos();

            return response;
        }
        [HttpPost]
        [Route("AddMaintenance")]
        public IActionResult AddMaintenance(AddMaintenanceRecordRequest maintenanceRequest)
        {
            _maintenancesRecordsServices.AddMaintenanceRecord(maintenanceRequest);
            return Ok("Maintenance added succesfully");
        }
    }
}
