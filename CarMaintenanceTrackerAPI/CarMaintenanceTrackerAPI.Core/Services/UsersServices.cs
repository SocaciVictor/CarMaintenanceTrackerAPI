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
        public IUserRepository _userRepository { get; set; }

        public UsersServices(
           IUserRepository usersRepository)
        {
            _userRepository = usersRepository;
        }
    }
}
