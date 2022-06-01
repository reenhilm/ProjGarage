namespace ProjGarage.Vehicles
{
    internal class Car : Vehicle
    {
        public CarFuelType FuelType { get; set; }
        public Car(string licenseplate) : base(licenseplate)
        {
        }
    }
}
