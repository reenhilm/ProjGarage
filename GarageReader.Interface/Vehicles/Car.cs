namespace VehicleReader.Interface.Vehicles
{
    public class Car : Vehicle
    {
        public CarFuelType FuelType { get; private set; }
        public Car(LicensePlate licenseplate) : base(licenseplate)
        {
        }
    }
}
