namespace ProjGarage.Vehicles
{
    internal class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }
        public Bus (string licenseplate) : base(licenseplate)
        {
        }
    }
}
