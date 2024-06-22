using CarMaintenanceTracker.Database.Entities;
using CarMaintenanceTrackerAPI.Core.Dtos.Response;
using CarMaintenanceTrackerAPI.Database.Repository;
using CarMaintenanceTrackerAPI.Core.Mapping;

namespace CarMaintenanceTrackerAPI.Core.Services
{
    public class CarsServices
    {
        private readonly ICarRepository _carRepository;

        public CarsServices(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public List<CarDto> GetCarDtos()
        {
            var cars = _carRepository.GetAllCars();

            List<CarDto> carDtos = new List<CarDto>();

            foreach (Car car in cars)
            {
                carDtos.Add(car.ToCarDto());
            }

            return carDtos;
        }
    }
}
