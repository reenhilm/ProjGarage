namespace VehicleReader.Interface.Vehicles
{
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; private set; }
        public Bus(LicensePlate licenseplate) : base(licenseplate)
        {
        }
    }
}
