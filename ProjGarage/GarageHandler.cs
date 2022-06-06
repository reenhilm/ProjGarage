using ProjGarage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGarage
{
    internal class GarageHandler : IGarageHandler
    {
        public IGarage<IVehicle> Garage { get; set; }

        public GarageHandler(int capacity)
        {
            this.Garage = new Garage<IVehicle>(capacity);
        }

        public GarageHandler(IGarage<IVehicle> garage)
        {
            this.Garage = garage;
        }

        public void ParkExampleVehicles()
        {
            ParkVehicle(new Car(new LicensePlate("ABC111")) { Color = VehicleColor.Red, WheelAmount = 3 });
            ParkVehicle(new Car(new LicensePlate("ABC112")));
            ParkVehicle(new Bus(new LicensePlate("BBB222")) { Color = VehicleColor.Red });
            ParkVehicle(new Motorcycle(new LicensePlate("CCC333")));
            ParkVehicle(new Boat(new LicensePlate("DDD444")));
            ParkVehicle(new Airplane(new LicensePlate("EEE555")) { Color = VehicleColor.Red });
        }

        public void ParkOneMoreExampleVehicle()
        {
            ParkVehicle(new Motorcycle(new LicensePlate("FFF666")) { Color = VehicleColor.Red });
        }

        public void UnparkVehicle(string Licenseplate)
        {
            Vehicle v = new(new LicensePlate(Licenseplate));
            UnparkVehicle(v);
        }

        public void ParkVehicle(IVehicle vehicle)
        {
            Garage.Add(vehicle);
        }

        public void UnparkVehicle(IVehicle vehicle)
        {
            Garage.Remove(vehicle);
        }

        public void GetVehiclesList(Action<string> print)
        {
            StringBuilder sb = new();
            foreach (IVehicle vehicle in Garage)
                sb.AppendLine(vehicle.ToString());

            print.Invoke(sb.ToString());
        }

        public void GetRedVehiclesList(Action<string> print)
        {
            StringBuilder sb = new();

            var redCars = Garage.Where(n => n.Color == VehicleColor.Red).ToList();

            foreach (IVehicle vehicle in redCars)
                sb.AppendLine(vehicle.ToString());

            print.Invoke(sb.ToString());
        }

        public bool GetVehicleByLicencePlate(Action<string> print, string LicensePlate)
        {
            var vehicle = Garage.FirstOrDefault(n => n.Licenseplate.Value == LicensePlate);
            if (vehicle != null)
            { 
                print.Invoke(vehicle.ToString());
                return true;
            }
            else
                return false;
        }
        public bool GetVehiclesByProperty(Action<string> print, Func<string> getInput)
        {
            IEnumerable<IVehicle> vehicles = null!;

            if (Util.AskUserWantsYes($"{Language.DoYouWantEnglish} {Language.TypeOfVehicleEnglish}", print, getInput))
            {
                string searchItem = Util.AskForTypeName(Language.EnterTypeEnglish, Language.TypeEnglish, print, getInput);
                vehicles = Garage.Where(n => n.GetType().Name == searchItem);
            }

            if (Util.AskUserWantsYes($"{Language.DoYouWantEnglish} {Language.ColorOfVehicleEnglish}", print, getInput))
            {
                VehicleColor searchItem = Util.AskForColor(Language.EnterColorEnglish, Language.ColorEnglish, print, getInput);
                vehicles = Garage.Where(n => n.Color == searchItem);
            }

            if (Util.AskUserWantsYes($"{Language.DoYouWantEnglish} {Language.WheelsOfVehicleEnglish}", print, getInput))
            {
                int searchItem = Util.AskForInt(Language.EnterAmountWheelsEnglish, Language.WheelsAmountEnglish, print, getInput);
                vehicles = Garage.Where(n => n.WheelAmount == searchItem);
            }

            if (vehicles == null)
                return false;
            else
            {
                vehicles.ToList().ForEach(vehicle => print.Invoke(vehicle.ToString()));
                return true;
            }
        }
        public void GetVehicleTypeAmountList(Action<string> print)
        {
            StringBuilder sb = new();

            var groups = Garage.GroupBy(n => n.GetType().Name)
                         .Select(n => new
                         {
                             VehicleTypeName = n.Key,
                             VehicleOfTypeCount = n.Count()
                         })
                         .OrderBy(n => n.VehicleTypeName);

            foreach (var type in groups)
                sb.AppendLine($"{type.VehicleOfTypeCount} {type.VehicleTypeName}");

            print.Invoke(sb.ToString());
        }
        //public static GarageHandler MiniGarage() => new(1);
        //public static GarageHandler SmallGarage() => new(10);
        //public static GarageHandler MediumGarage() => new(20);
    }
}
