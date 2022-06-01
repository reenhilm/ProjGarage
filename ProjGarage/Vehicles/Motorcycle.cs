namespace ProjGarage.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; set; }
        public Motorcycle(string licenseplate) : base(licenseplate)
        {
        }
    }
}
