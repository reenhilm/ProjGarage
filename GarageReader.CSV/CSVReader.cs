using VehicleReader.Interface.Vehicles;

namespace VehicleReader.CSV
{
    public class CSVReader //: IVehicleReader
    {
        public ICSVFileLoader FileLoader { get; set; }

        public CSVReader()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Garage.txt";
            FileLoader = new CSVFileLoader(filePath);
        }

        public IEnumerable<IVehicle> GetGarage()
        {
            var fileData = FileLoader.LoadFile();
            var garage = ParseData(fileData);
            return garage;
        }

        private List<IVehicle> ParseData(IReadOnlyCollection<string> csvData)
        {
            var vehicles = new List<IVehicle>();

            foreach (string line in csvData)
            {
                try
                {
                    var elems = line.Split(',');
                    var veh = new Vehicle(new LicensePlate("ABC123"));
                    {
                        //Id = Int32.Parse(elems[0]),
                        //GivenName = elems[1],
                        //FamilyName = elems[2],
                        //StartDate = DateTime.Parse(elems[3]),
                        //Rating = Int32.Parse(elems[4]),
                        //FormatString = elems[5],
                    };
                    vehicles.Add(veh);
                }
                catch (Exception)
                {
                    // Skip the bad record, log it, and move to the next record
                    // log.write("Unable to parse record", per);
                }
            }
            return vehicles;
        }
    }
}