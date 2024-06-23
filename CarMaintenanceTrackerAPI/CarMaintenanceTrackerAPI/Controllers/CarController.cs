using CarMaintenanceTrackerAPI.Core.Dtos.Request;
using CarMaintenanceTrackerAPI.Core.Dtos.Response;
using CarMaintenanceTrackerAPI.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarMaintenanceTrackerAPI.Controllers
{
    [Route("api/Cars")]
    public class CarController : BaseController
    {
        private readonly CarsServices _carsServices;
        
        public CarController(CarsServices carsServices)
        {
            _carsServices = carsServices;
        }

        [HttpGet]
        [Route("GetCars")]
        [Authorize(Roles = "0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CarDto>> GetCar()
        {
            var response = _carsServices.GetCarDtos();

            return response;
        }

        [HttpPost]
        [Route("AddCar")]
        [Authorize(Roles = "0")]
        public IActionResult AddCar([FromBody] AddCarRequest addCarRequest)
        {
            _carsServices.AddCarToUser(addCarRequest);

            return Ok("Car added");
        }
        [HttpGet]
        [Route("GetCarOfOwner")]
        [Authorize(Roles = "0,1")]
        public ActionResult<CarDto> GetCarOfOwner()
        {
            var authUserId = GetUserId();
            var response = _carsServices.GetCarDtoOfAOwner(authUserId);

            return response;
        }
        [HttpPut]
        [Route("{carId}/edit-car")]
        [Authorize(Roles = "0")]
        public IActionResult EditMaintenance([FromRoute] int carId, [FromBody] EditCarRequest payload)
        {
            var authUserId = GetUserId();
            _carsServices.EditCar(payload, carId,authUserId);


            return Ok("Car has been successfully edited");
        }

    }
}
