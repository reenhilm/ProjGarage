using ProjGarage.Vehicles;

namespace ProjGarage
{
    internal interface IGarageHandler
    {
        IGarage<IVehicle> Garage { get; set; }
        bool PrintVehicleByLicencePlate(Action<string> print, string LicensePlate);
        void PrintRedVehiclesList(Action<string> print);
        void PrintVehiclesList(Action<string> print);
        void PrintVehicleTypeAmountList(Action<string> print);
        void ParkExampleVehicles(Action<string> print);
        void ParkOneMoreExampleVehicle(Action<string> print);
        void ParkVehicle(string Licenseplate, Action<string> print);
        void UnParkVehicle(string Licenseplate, Action<string> print);
        void PrintVehiclesByProperty(Action<string> print, Func<string> getInput);
    }
}