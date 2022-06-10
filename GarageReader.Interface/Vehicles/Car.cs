namespace VehicleReader.Interface.Vehicles
{
    public class Car : Vehicle
    {
        public CarFuelType FuelType { get; set; }
        public Car(LicensePlate licenseplate) : base(licenseplate)
        {
        }
    }
}
