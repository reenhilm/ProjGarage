namespace ProjGarage.Vehicles
{
    internal class Vehicle : IVehicle
    {
        public string Licenseplate { get; set; }
        public VehicleColor Color { get; set; } = VehicleColor.Unpainted;
        public int WheelAmount { get; set; }

        public Vehicle(string licenseplate)
        {
            Licenseplate = licenseplate;
        }

        public override string ToString()
        {
            return Licenseplate;
        }
    }
}
