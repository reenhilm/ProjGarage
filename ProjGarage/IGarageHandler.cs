using ProjGarage.Vehicles;

namespace ProjGarage
{
    internal interface IGarageHandler
    {
        IGarage<IVehicle> Garage { get; set; }

        bool GetVehicleByLicencePlate(Action<string> print, string LicensePlate);
        void GetRedVehiclesList(Action<string> print);
        void GetVehiclesList(Action<string> print);
        void GetVehicleTypeAmountList(Action<string> print);
        void ParkExampleVehicles();
        void ParkOneMoreExampleVehicle();
        void ParkVehicle(IVehicle vehicle);
        void UnparkVehicle(IVehicle vehicle);
        void UnparkVehicle(string Licenseplate);
        bool GetVehiclesByProperty(Action<string> print, Func<string> getInput);
    }
}