using CarMaintenanceTracker.Database.Context;
using CarMaintenanceTracker.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Database.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(CarMaintenanceTrackerDbContext carMaintenanceTrackerDbContext) : base(carMaintenanceTrackerDbContext)
        {
            
        }
        public List<User> GetAllUsers()
        {
            var result = _carMaintenanceTrackerDbContext.Users.
                ToList();
            return result;
        }
    }
}
