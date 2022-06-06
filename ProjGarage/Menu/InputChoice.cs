using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGarage.Menu
{
    internal class InputChoice
    {
        public InputChoice(string selectedinput)
        {
            if (int.TryParse(selectedinput, out int iSelectedInput))
            {
                List<int> validSelections = new ();
                foreach (int i in Enum.GetValues(typeof(InputEnum)))
                    validSelections.Add(i);

                if (validSelections.IndexOf(iSelectedInput) != -1)
                    Input = (InputEnum)Enum.Parse(typeof(InputEnum), iSelectedInput.ToString());
                else
                    Input = InputEnum.Invalid;
            }
            else
                Input = InputEnum.Invalid;
        }


        public InputEnum Input { get; private set; }
        public string Description {
            get
            {
                return GetDescriptionForInput(Input);
            }
        }

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
        



        private readonly static string ExitDescription = string.Concat((int)InputEnum.Exit, Language.ExitEnglish);
        private readonly static string InvalidDescription = Language.InvalidEnglish;


    }
}
