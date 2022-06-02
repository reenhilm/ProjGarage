using ProjGarage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGarage
{
    internal class GarageHandler
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
            ParkVehicle(new Car("ABC111") { Color = VehicleColor.Red });
            ParkVehicle(new Car("ABC112"));
            ParkVehicle(new Bus("ABC222") { Color = VehicleColor.Red });
            ParkVehicle(new Motorcycle("ABC333"));
            ParkVehicle(new Boat("ABC444"));
            ParkVehicle(new Airplane("ABC555") { Color = VehicleColor.Red });
        }

        public void ParkOneMoreExampleVehicle()
        {
            ParkVehicle(new Motorcycle("ABC666") { Color = VehicleColor.Red });
        }

        public void UnparkVehicle(string Licenseplate)
        {
            Vehicle v = new(Licenseplate);
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
            
            foreach(IVehicle vehicle in redCars)
                sb.AppendLine(vehicle.ToString());

            print.Invoke(sb.ToString());
        }

        public void GetVehicleTypeAmountList(Action<string> print)
        {
            StringBuilder sb = new();

            var groups = Garage.GroupBy(n => n.GetType().Name)
                         .Select(n => new
                         {
                             MetricName = n.Key,
                             MetricCount = n.Count()
                         })
                         .OrderBy(n => n.MetricName);

            foreach (var type in groups)
                sb.AppendLine($"{type.MetricCount} {type.MetricName}");

            print.Invoke(sb.ToString());
        }
        public static GarageHandler SmallGarage() => new(10);
        public static GarageHandler MediumGarage() => new(20);
    }
}
