namespace ProjGarage.Vehicles
{
    internal class Airplane : Vehicle
    {
        public int NumberOfEngies { get; set; }
        public Airplane(string licenseplate) : base(licenseplate)
        {
        }
    }
}
