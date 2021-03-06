using Microsoft.Extensions.Configuration;
using ProjGarage.Menu;
using VehicleReader.Interface.Vehicles;

namespace ProjGarage
{
    public class Manager
    {
        private IUI ui;
        private IGarageHandler? garageHandler;
        private IConfiguration configuration;
        bool ExampleCarsRun = false;
        public Manager(IUI consoleUI, IConfiguration configuration)
        {
            this.ui = consoleUI;
            this.configuration = configuration;
        }
        private void Exit()
        {
            ui.Write(Language.ExitingEnglish);
            Environment.Exit(0);
        }
        private void Menu()
        {
            InputChoice inputChoice;
            do
            {
                PrintMainMenu();
                inputChoice = new InputChoice(ui.GetInput() ?? string.Empty);

                ui.Write(inputChoice.Description);
                switch (inputChoice.Input)
                {
                    case InputEnum.Main_ListAllVehicles:
                        ListAllVehicles();
                        break;
                    case InputEnum.Main_ListVehicleTypes:
                        ListAllVehicleTypes();
                        break;
                    case InputEnum.Main_FindVehicleByLicensePlate:
                        FindVehicleByLicencePlate();
                        break;
                    case InputEnum.Main_PopulateWithExamples:
                        PopulateWithExamples();
                        break;
                    case InputEnum.Main_FindVehicleByProperty:
                        FindVehicleByProperty();
                        break;
                    case InputEnum.Main_ParkVehicle:
                        Main_ParkVehicle();
                        break;
                    case InputEnum.Main_UnParkVehicle:
                        Main_UnParkVehicle();
                        break;
                }
            }
            while (inputChoice.Input != InputEnum.Exit);
        }
        private void Main_UnParkVehicle()
        {
            var plate = Util.AskForLicensePlate(ui.Write, ui.GetInput);
            garageHandler!.UnParkVehicle(plate.Value, ui.Write);
        }
        private void Main_ParkVehicle()
        {
            var plate = Util.AskForLicensePlate(ui.Write, ui.GetInput);
            garageHandler!.ParkVehicle(plate.Value, ui.Write);
        }
        private void FindVehicleByProperty() => garageHandler!.PrintVehiclesByProperty(ui.Write, ui.GetInput);
        private void FindVehicleByLicencePlate()
        {
            if (!garageHandler!.PrintVehicleByLicencePlate(ui.Write, Util.AskForLicensePlate(ui.Write, getLine: ui.GetInput).Value))
                ui.Write(Language.VNotFoundEnglish);
        }
        private void PrintMainMenu()
        {
            ui.Write(Language.Choose);
            //TODO unit test menu is visible
            ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Main_ListAllVehicles));
            ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Main_ListVehicleTypes));
            if (!ExampleCarsRun)
                ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Main_PopulateWithExamples));
            ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Main_FindVehicleByLicensePlate));
            ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Main_FindVehicleByProperty));
            ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Main_ParkVehicle));
            ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Main_UnParkVehicle));
            ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Exit));
        }
        internal void ListAllVehicles() => garageHandler!.PrintVehiclesList(ui.Write);
        internal void ListAllVehicleTypes() => garageHandler!.PrintVehicleTypeAmountList(ui.Write);
        internal void Start()
        {
            //TODO Ask if want to load
            bool UserWantsLoad = true;
            bool GarageWasLoaded = false;
            do
            {
                UserWantsLoad = Util.AskUserWantsYes("Do you want to load garage from file?", ui.Write, ui.GetInput);
                if (UserWantsLoad)
                {
                    VehicleController vc = new(configuration);
                    IGarage<IVehicle>? garage = null;
                    try
                    {
                        garage = vc.UseReader() as IGarage<IVehicle>;
                    }
                    catch(System.IO.FileNotFoundException e)
                    {
                        ui.Write(Language.FileNotFound);
                    }
                    if (garage != null)
                    {
                        this.garageHandler = new GarageHandler(garage);
                        GarageWasLoaded = true;
                        UserWantsLoad = false;
                    }
                }
            }
            while (UserWantsLoad);

            if(!GarageWasLoaded)
            { 
                //If not load, Ask what size for new garage and create
                int iCapacity = Util.AskForInt(Language.EnterGarageSizeEnglish, Language.GarageSizeEnglish, ui.Write, getLine: ui.GetInput);
                this.garageHandler = new GarageHandler(iCapacity);
            }

            Menu();
            Exit();          
                        
            //ui.Write("Red vehicles:");
            //garageHandler.GetRedVehiclesList(ui.Write);
        }
        private void PopulateWithExamples()
        {
            garageHandler!.ParkExampleVehicles(ui.Write); //<- 6st fordon varav 3 röda
            ExampleCarsRun = true;
        }
    }
}