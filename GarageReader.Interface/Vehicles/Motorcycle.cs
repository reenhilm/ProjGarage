namespace VehicleReader.Interface.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; private set; }
        public Motorcycle(LicensePlate licenseplate) : base(licenseplate)
        {
        }
    }
}
