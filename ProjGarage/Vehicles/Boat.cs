namespace ProjGarage.Vehicles
{
    internal class Boat : Vehicle
    {
        public int Length { get; set; }
        public Boat (string licenseplate) : base(licenseplate)
        {
        }
    }
}
