using CarMaintenanceTracker.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Database.Repository
{
    public interface ICarServiceCenter
    {

        List<CarServiceCenter> GetAllCarServiceCenters();
        void AddCarServiceCenter(CarServiceCenter carServiceCenter);
        void EditCarId(int carId, int oldCarId);
        void EditServiceId(int serviceCenterId, int oldServiceCenterId);
    }
}
