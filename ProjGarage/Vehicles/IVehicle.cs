namespace ProjGarage.Vehicles
{
    internal interface IVehicle
    {
        VehicleColor Color { get; set; }
        string Licenseplate { get; set; }
        int WheelAmount { get; set; }      
        string ToString();
    }
}