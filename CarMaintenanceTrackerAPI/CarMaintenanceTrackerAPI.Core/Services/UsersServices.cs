using CarMaintenanceTracker.Database.Entities;
using CarMaintenanceTrackerAPI.Core.Dtos.Request;
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
    public class UsersServices
    {
        public AuthServices _authServices { get; set; }
        public IUserRepository _userRepository { get; set; }

        public UsersServices(
            AuthServices authService,
           IUserRepository usersRepository)
        {
            _userRepository = usersRepository;
            _authServices = authService;

        }

        public List<UserDto> GetUsersDto()
        {
            var users = _userRepository.GetAllUsers();

            List<UserDto> userDtos = new List<UserDto>();

            foreach (User user in users)
            {
                userDtos.Add(user.ToUserDto());
            }

            return userDtos;
        }

        public void Register(RegisterRequest registerData)
        {
            if (registerData == null)
            {
                return;
            }

            var salt = _authServices.GenerateSalt();
            var hashedPassword = _authServices.HashPassword(registerData.Password, salt);

            var user = new User();
            user.FirstName = registerData.FirstName;
            user.LastName = registerData.LastName;
            user.Email = registerData.Email;
            user.Username = registerData.Username;
            user.Password = hashedPassword;
            user.Type = registerData.Type;
            user.PasswordSalt = Convert.ToBase64String(salt);

            _userRepository.Add(user);
        }

        public string Login(LoginRequest payload)
        {
            var user = _userRepository.GetByEmail(payload.Email);

            if (_authServices.HashPassword(payload.Password, Convert.FromBase64String(user.PasswordSalt)) == user.Password)
            {
                var role = user.Type.ToString();

                return _authServices.GetToken(user, role);
            }
            else
            {
                return null;
            }
        }
    }
}
