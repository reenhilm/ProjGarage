using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGarage.Menu
{
    internal enum InputEnum
    {
        Exit = 0,
        Main_ListAllVehicles = 1,
        Main_ListVehicleTypes = 2,
        Main_AddOrRemoveVechicles = 3,
        Main_PopulateWithExamples = 4,
        Main_FindVehicleByLicensePlate = 5,
        Main_FindVehicleByProperty = 6,
        Invalid = int.MaxValue
    }
}
