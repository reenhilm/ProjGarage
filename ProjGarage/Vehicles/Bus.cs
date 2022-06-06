namespace ProjGarage.Vehicles
{
    internal class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }
        public Bus (LicensePlate licenseplate) : base(licenseplate)
        {
        }
    }
}
