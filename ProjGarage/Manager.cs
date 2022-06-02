namespace ProjGarage
{
    internal class Manager
    {
        private IUI ui;
        private GarageHandler garageHandler;
        public Manager(IUI consoleUI)
        {
            this.ui = consoleUI;
            this.garageHandler = GarageHandler.MediumGarage();
        }
        internal void Start()
        {
            garageHandler.ParkExampleVehicles(); //<- 6st fordon varav 3 röda
            garageHandler.UnparkVehicle("ABC222"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen
            garageHandler.ParkOneMoreExampleVehicle(); //<- en röd motorcykel till
            garageHandler.UnparkVehicle("ABC666"); //<- röda bussen


            ui.Write("Red vehicles:");
            garageHandler.GetRedVehiclesList(ui.Write);

            ui.Write("All vehicles:");
            garageHandler.GetVehiclesList(ui.Write);

            ui.Write("All vehicletypes and amount:");
            garageHandler.GetVehicleTypeAmountList(ui.Write);
        }
    }
}