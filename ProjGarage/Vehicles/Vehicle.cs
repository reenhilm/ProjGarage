using System.Diagnostics.CodeAnalysis;

namespace ProjGarage.Vehicles
{
    internal class Vehicle : LicensePlate, IVehicle
    {
        public LicensePlate Licenseplate { get; init; }

        public VehicleColor Color { get; set; } = VehicleColor.Unpainted;
        public int WheelAmount { get; set; }

        public Vehicle(LicensePlate licenseplate) : base(licenseplate.Value)
        {
            this.Licenseplate = licenseplate;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
