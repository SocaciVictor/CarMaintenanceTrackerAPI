using CarMaintenanceTracker.Database.Context;
using CarMaintenanceTracker.Database.Entities;
using Microsoft.EntityFrameworkCore;
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
            var result = _carMaintenanceTrackerDbContext.Users
                .Include(u => u.Car)
                .ToList();
            return result;
        }

        public User GetByEmail(string email)
        {
            var result = _carMaintenanceTrackerDbContext.Users
                .FirstOrDefault(x => x.Email == email);

            return result;
        }

        public void Add(User user)
        {
            _carMaintenanceTrackerDbContext.Users.Add(user);
            _carMaintenanceTrackerDbContext.SaveChanges();
        }
    }
}
