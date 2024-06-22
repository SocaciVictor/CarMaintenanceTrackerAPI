using CarMaintenanceTracker.Database.Entities;
using CarMaintenanceTrackerAPI.Core.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Core.Mapping
{
    public static class CarExtensionMethod
    {
        public static CarDto ToCarDto(this Car car)
        {
            return new CarDto
            {
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                LicensePlate = car.LicensePlate,
                OwnerName = car.User.FirstName + " " + car.User.LastName
            };
        }
    }
}
