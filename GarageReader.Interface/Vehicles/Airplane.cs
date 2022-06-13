namespace VehicleReader.Interface.Vehicles
{
    public class Airplane : Vehicle
    {
        public int NumberOfEngies { get; private set; }
        public Airplane(LicensePlate licenseplate) : base(licenseplate)
        {
        }
    }
}
