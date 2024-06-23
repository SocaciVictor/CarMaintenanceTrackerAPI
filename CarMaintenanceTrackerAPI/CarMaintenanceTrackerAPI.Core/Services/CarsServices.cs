using CarMaintenanceTracker.Database.Entities;
using CarMaintenanceTrackerAPI.Core.Dtos.Response;
using CarMaintenanceTrackerAPI.Database.Repository;
using CarMaintenanceTrackerAPI.Core.Mapping;
using CarMaintenanceTrackerAPI.Core.Dtos.Request;

namespace CarMaintenanceTrackerAPI.Core.Services
{
    public class CarsServices
    {
        private readonly ICarRepository _carRepository;

        private readonly IUserRepository _userRepository;

        public CarsServices(ICarRepository carRepository, IUserRepository userRepository)
        {
            _carRepository = carRepository;
            _userRepository = userRepository;
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

        public void AddCarToUser (AddCarRequest addCarRequest)
        {
            var car = addCarRequest.ToEntity();

            if(ValidateUser(car.UserId))
                _carRepository.AddCar(car);
        }


        private bool ValidateUser(int userId)
        {
            var user = _userRepository.ValidateUser(userId);

            if (user == false)
            {
                throw new Exception("User not found");
            }
            return true;
        }   
    }
}
