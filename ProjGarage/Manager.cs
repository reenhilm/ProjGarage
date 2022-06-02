namespace ProjGarage
{
    internal class Manager
    {
        private IUI ui;
        private IGarageHandler? garageHandler;
        public Manager(IUI consoleUI)
        {
            this.ui = consoleUI;            
        }
        internal void Start()
        {
            //Fråga vilken storlek

            //Fråga om man vill ladda tidigare garage
            this.garageHandler = GarageHandler.SmallGarage();
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