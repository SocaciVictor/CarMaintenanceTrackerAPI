using CarMaintenanceTrackerAPI.Core.Dtos.Request;
using CarMaintenanceTrackerAPI.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarMaintenanceTrackerAPI.Controllers
{
    [Route("api/Users")]
    public class UsersController : Controller
    {

        private UsersServices _usersServices { get; set; }

        public UsersController(UsersServices usersServices)
        {
            _usersServices = usersServices;
        }


        [HttpPost("/register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterRequest payload)
        {
            _usersServices.Register(payload);
            return Ok("Registration successful");
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequest payload)
        {
            var jwtToken = _usersServices.Login(payload);

            return Ok(new { token = jwtToken });
        }
    }
}
