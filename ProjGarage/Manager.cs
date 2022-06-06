using ProjGarage.Menu;
using ProjGarage.Vehicles;

namespace ProjGarage
{
    public class Manager
    {
        private IUI ui;
        private IGarageHandler? garageHandler;
        bool ExampleCarsParked = false;
        public Manager(IUI consoleUI)
        {
            this.ui = consoleUI;            
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
                }
            }
            while (inputChoice.Input != InputEnum.Exit);
        }

        private void FindVehicleByProperty()
        {
            if(!garageHandler!.GetVehiclesByProperty(ui.Write, ui.GetInput))
                ui.Write(Language.VNotFoundEnglish);
        }

        private void FindVehicleByLicencePlate()
        {
            if (!garageHandler!.GetVehicleByLicencePlate(ui.Write, Util.AskForLicensePlate(Language.EnterLicencePlateEnglish, Language.LicencePlateEnglish, ui.Write, getLine: ui.GetInput).Value))
                ui.Write(Language.VNotFoundEnglish);
        }
        private void PrintMainMenu()
        {
            ui.Write(Language.Choose);
            //TODO unit test menu is visible
            ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Main_ListAllVehicles));
            ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Main_ListVehicleTypes));
            //ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Main_AddOrRemoveVechicles));
            if(!ExampleCarsParked)
                ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Main_PopulateWithExamples));
            ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Main_FindVehicleByLicensePlate));
            ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Main_FindVehicleByProperty));
            ui.Write(InputChoice.GetDescriptionForInput(InputEnum.Exit));
        }
        internal void ListAllVehicles() => garageHandler!.GetVehiclesList(ui.Write);
        internal void ListAllVehicleTypes() => garageHandler!.GetVehicleTypeAmountList(ui.Write);
        internal void Start()
        {
            //TODO Ask if want to load

            //If not load, Ask what size for new garage and create
            int iCapacity = Util.AskForInt(Language.EnterGarageSizeEnglish, Language.GarageSizeEnglish, ui.Write, getLine: ui.GetInput);
            this.garageHandler = new GarageHandler(iCapacity);

            Menu();
            Exit();          
                        
            //ui.Write("Red vehicles:");
            //garageHandler.GetRedVehiclesList(ui.Write);
        }
        private void PopulateWithExamples()
        {
            garageHandler!.ParkExampleVehicles(); //<- 6st fordon varav 3 röda
            ExampleCarsParked = true;
        }
    }
}