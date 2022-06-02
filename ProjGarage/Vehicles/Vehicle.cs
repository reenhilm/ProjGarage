using System.Diagnostics.CodeAnalysis;

namespace ProjGarage.Vehicles
{
    internal class Vehicle : IVehicle
    {
        public string Licenseplate { get; init; }

        public VehicleColor Color { get; set; } = VehicleColor.Unpainted;
        public int WheelAmount { get; set; }

        public Vehicle(string licenseplate)
        {
            Licenseplate = licenseplate.ToUpper();
        }

        public override string ToString()
        {
            return Licenseplate;
        }
    }
}
