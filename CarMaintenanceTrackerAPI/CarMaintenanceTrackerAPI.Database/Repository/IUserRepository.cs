using CarMaintenanceTracker.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Database.Repository
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User GetByEmail(string email);
        void Add(User user);
    }
}
