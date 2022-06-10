namespace VehicleReader.Interface.Vehicles
{
    public class Airplane : Vehicle
    {
        public int NumberOfEngies { get; set; }
        public Airplane(LicensePlate licenseplate) : base(licenseplate)
        {
        }
    }
}
