using CarMaintenanceTracker.Database.Entities;
using CarMaintenanceTrackerAPI.Core.Dtos.Response;
using CarMaintenanceTrackerAPI.Database.Repository;
using CarMaintenanceTrackerAPI.Core.Mapping;
using CarMaintenanceTrackerAPI.Core.Dtos.Request;
using CarMaintenanceTrackerAPI.Infrastructure.Exceptions;

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
        public void EditCar(EditCarRequest editCarRequest,int carId,int authUserId)
        {
            var car=_carRepository.GetCarById(carId);
            if(car.UserId!=authUserId)
                throw new ForbiddenException("Forbidden");

            if (ValidateUser(editCarRequest.UserId))
            {
                SwitchingCarDetails(editCarRequest,car);
                _carRepository.EditCar(car);
            }
        }


        private bool ValidateUser(int userId)
        {
            var user = _userRepository.ValidateUser(userId);

            if (user == false)
            {
                throw new ResourceMissingException("User not found");
            }
            return true;
        }   
        private void SwitchingCarDetails(EditCarRequest editCarRequest,Car car)
        {
            car.Make=editCarRequest.Make;
            car.UserId=editCarRequest.UserId;
            car.LicensePlate=editCarRequest.LicensePlate;
            car.Model=editCarRequest.Model;
            car.Year=Int32.Parse(editCarRequest.Year);
        }
    }
}
