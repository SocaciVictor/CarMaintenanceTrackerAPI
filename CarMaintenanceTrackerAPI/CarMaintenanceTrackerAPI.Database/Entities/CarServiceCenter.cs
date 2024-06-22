namespace CarMaintenanceTracker.Database.Entities
{
    public class CarServiceCenter
    {
        public int CarId { get; set; }
        public Car? Car { get; set; }

        public int ServiceCenterId { get; set; }
        public ServiceCenter? ServiceCenter { get; set; }
    }
}