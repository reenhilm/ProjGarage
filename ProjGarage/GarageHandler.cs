using VehicleReader.Interface.Vehicles;

namespace ProjGarage
{
    internal class GarageHandler : IGarageHandler
    {
        public IGarage<IVehicle> Garage { get; set; }
        public GarageHandler(int capacity) => this.Garage = new Garage<IVehicle>(capacity);
        public GarageHandler(IGarage<IVehicle> garage) => this.Garage = garage;
        public void ParkExampleVehicles(Action<string> print)
        {           
            if (!ParkVehicle(new Car(new LicensePlate("ABC111")) { Color = VehicleColor.Red, WheelAmount = 3 }, print))
                return;
            if (!ParkVehicle(new Car(new LicensePlate("ABC112")), print))
                return;
            if (!ParkVehicle(new Bus(new LicensePlate("BBB222")) { Color = VehicleColor.Red }, print))
                return;
            if (!ParkVehicle(new Motorcycle(new LicensePlate("CCC333")), print))
                return;
            if (!ParkVehicle(new Boat(new LicensePlate("DDD444")), print))
                return;
            if (!ParkVehicle(new Airplane(new LicensePlate("EEE555")) { Color = VehicleColor.Red }, print))
                return;
        }
        public void ParkOneMoreExampleVehicle(Action<string> print) => ParkVehicle(new Motorcycle(new LicensePlate("FFF666")) { Color = VehicleColor.Red }, print);
        public void UnParkVehicle(string Licenseplate, Action<string> print) => UnParkVehicle(new Vehicle(new LicensePlate(Licenseplate)), print);
        private void UnParkVehicle(IVehicle vehicle, Action<string> print)
        {
            if(Garage.Remove(vehicle))
                print.Invoke(Language.VWasUnParkedEnglish);

            else
                print.Invoke(Language.VNotFoundEnglish);
        }
        public void ParkVehicle(string Licenseplate, Action<string> print) => ParkVehicle(new Vehicle(new LicensePlate(Licenseplate)), print);
        private bool ParkVehicle(IVehicle vehicle, Action<string> print)
        {
            string reason = string.Empty;
            bool bSuccess;
            try
            {
                bSuccess = Garage.Add(vehicle);
            }
            catch(ArgumentOutOfRangeException)
            {
                bSuccess = false;
                reason = Language.GarageFullEnglish;
            }
            catch(DuplicatePlateException)
            {
                bSuccess = false;
                reason = Language.VAlreadyParkedEnglish;
            }

            if (bSuccess)
            {
                print.Invoke(Language.VWasParkedEnglish);
                return true;
            }
            else
            {
                print.Invoke(reason);
                return false;
            }
        }
        public void PrintVehiclesList(Action<string> print)
        {
            StringBuilder sb = new();
            foreach (IVehicle vehicle in Garage)
                sb.AppendLine(vehicle.ToString());

            print.Invoke(sb.ToString());
        }
        public void PrintRedVehiclesList(Action<string> print)
        {
            StringBuilder sb = new();

            var redCars = Garage.Where(n => n.Color == VehicleColor.Red).ToList();

            foreach (IVehicle vehicle in redCars)
                sb.AppendLine(vehicle.ToString());

            print.Invoke(sb.ToString());
        }
        public bool PrintVehicleByLicencePlate(Action<string> print, string LicensePlate)
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
        public void PrintVehiclesByProperty(Action<string> print, Func<string> getInput)
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

            var vehiclesList = vehicles.ToList();

            if (vehiclesList.Count() == 0)
                print.Invoke(Language.VNotFoundEnglish);
            else
                vehiclesList.ForEach(vehicle => print.Invoke(vehicle.ToString()));
        }
        public void PrintVehicleTypeAmountList(Action<string> print)
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
