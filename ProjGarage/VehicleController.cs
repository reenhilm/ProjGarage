using Microsoft.Extensions.Configuration;
using VehicleReader.Factory;
using VehicleReader.Interface;
using VehicleReader.Interface.Vehicles;

namespace ProjGarage
{
    public class VehicleController
    {
        private ReaderFactory readerFactory;

        public VehicleController(IConfiguration configuration)
        {
            readerFactory = new ReaderFactory(configuration);
        }

        public IEnumerable<IVehicle> UseReader()
        {
            IVehicleReader reader = readerFactory.GetReader();
            IEnumerable<IVehicle> garage = reader.GetGarage();
            return garage;
        }
    }
}
