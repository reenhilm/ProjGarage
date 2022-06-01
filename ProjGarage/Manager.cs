namespace ProjGarage
{
    internal class Manager
    {
        private IUI ui;
        private GarageHandler garageHandler;
        public Manager(IUI consoleUI, GarageHandler garageHandler)
        {
            this.ui = consoleUI;
            this.garageHandler = garageHandler;
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


            Console.WriteLine("Red vehicles:");
            Console.Write(garageHandler.GetRedVehiclesList());

            Console.WriteLine("All vehicles:");
            Console.Write(garageHandler.GetVehiclesList());

            Console.WriteLine("All vehicletypes and amount:");
            Console.Write(garageHandler.GetVehicleTypeAmountList());
        }
    }
}