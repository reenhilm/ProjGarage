using VehicleReader.Interface.Vehicles;

namespace VehicleReader.Interface
{
    public interface IVehicleReader
    {
        public IEnumerable<IVehicle> GetGarage();
    }
}
