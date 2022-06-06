namespace ProjGarage.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; set; }
        public Motorcycle(LicensePlate licenseplate) : base(licenseplate)
        {
        }
    }
}
