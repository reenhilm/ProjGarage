namespace ProjGarage.Menu
{
    internal class InputChoice
    {
        public InputChoice(string selectedinput)
        {
            if (Enum.TryParse<InputEnum>(selectedinput, true, out InputEnum parsedEnum))
                Input = parsedEnum;
            else
                Input = InputEnum.Invalid;
        }
        public InputEnum Input { get; private set; }
        public string Description => GetDescriptionForInput(Input);
        public static string GetDescriptionForInput(InputEnum input)
        {
            //TODO unit test input enum has description
            return input switch
            {
                //mainMenu
                InputEnum.Main_ListAllVehicles => Main_ListAllVehiclesDescription,
                InputEnum.Main_ListVehicleTypes => Main_ListVehicleTypesDescription,
                InputEnum.Main_FindVehicleByLicensePlate => Main_FindVehicleByLicencePlateDescription,
                InputEnum.Main_PopulateWithExamples => Main_PopulateWithExamplesDescription,
                InputEnum.Main_FindVehicleByProperty => Main_FindVehicleByPropertyDescription,
                InputEnum.Main_UnParkVehicle => Main_UnParkVehicleDescription,
                InputEnum.Main_ParkVehicle => Main_ParkVehicleDescription,
                InputEnum.Exit => ExitDescription,
                InputEnum.Invalid => InvalidDescription,
                _ => InvalidDescription,
            };
        }

        private readonly static string Main_ListAllVehiclesDescription = string.Concat((int)InputEnum.Main_ListAllVehicles, Language.Main_ListAllVehiclesEnglish);
        private readonly static string Main_ListVehicleTypesDescription = string.Concat((int)InputEnum.Main_ListVehicleTypes, Language.Main_ListVehicleTypesEnglish);
        private readonly static string Main_FindVehicleByLicencePlateDescription = string.Concat((int)InputEnum.Main_FindVehicleByLicensePlate, Language.Main_FindVehicleByLicencePlateEnglish);
        private readonly static string Main_PopulateWithExamplesDescription = string.Concat((int)InputEnum.Main_PopulateWithExamples, Language.Main_PopulateWithExamplesEnglish);
        private readonly static string Main_FindVehicleByPropertyDescription = string.Concat((int)InputEnum.Main_FindVehicleByProperty, Language.Main_FindVehicleByPropertyEnglish);
        private readonly static string Main_UnParkVehicleDescription = string.Concat((int)InputEnum.Main_UnParkVehicle, Language.Main_UnParkVehicleEnglish);
        private readonly static string Main_ParkVehicleDescription = string.Concat((int)InputEnum.Main_ParkVehicle, Language.Main_ParkVehicleEnglish);

        private readonly static string ExitDescription = string.Concat((int)InputEnum.Exit, Language.ExitEnglish);
        private readonly static string InvalidDescription = Language.InvalidEnglish;
    }
}
