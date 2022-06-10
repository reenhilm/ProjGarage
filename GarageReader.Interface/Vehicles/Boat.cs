namespace VehicleReader.Interface.Vehicles
{
    public class Boat : Vehicle
    {
        public int Length { get; set; }
        public Boat(LicensePlate licenseplate) : base(licenseplate)
        {
        }
    }
}
