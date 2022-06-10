namespace VehicleReader.Interface.Vehicles
{
    public class Vehicle : LicensePlate, IVehicle
    {
        public LicensePlate Licenseplate { get; init; }
        public VehicleColor Color { get; set; } = VehicleColor.Unpainted;
        public int WheelAmount { get; set; }
        public Vehicle(LicensePlate licenseplate) : base(licenseplate.Value) => Licenseplate = licenseplate;
        public override string ToString() => Value;
    }
}
