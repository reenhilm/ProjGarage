namespace VehicleReader.Interface.Vehicles
{
    public interface IVehicle
    {
        VehicleColor Color { get; set; }
        LicensePlate Licenseplate { get; init; }
        int WheelAmount { get; set; }
        string ToString();
    }
}