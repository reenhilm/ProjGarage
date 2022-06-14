using Microsoft.Extensions.Configuration;
using System.Reflection;
using VehicleReader.Interface;

namespace VehicleReader.Factory
{
    public class ReaderFactory
    {
        private IConfiguration Configuration;
        public ReaderFactory(IConfiguration configuration) => Configuration = configuration;
        private IVehicleReader? reader;
        public IVehicleReader GetReader()
        {
            if (reader != null)
                return reader;

            // Check configuration
            string? appsettingsReaderAssemblyName = Configuration["DataReader:ReaderAssembly"];
            string readerLocation = AppDomain.CurrentDomain.BaseDirectory
                                    + "ReaderAssemblies"
                                    + Path.DirectorySeparatorChar
                                    + appsettingsReaderAssemblyName;

            // Load the assembly
            ReaderLoadContext loadContext = new ReaderLoadContext(readerLocation);
            AssemblyName assemblyName = new AssemblyName(Path.GetFileNameWithoutExtension(readerLocation));
            Assembly readerAssembly = loadContext.LoadFromAssemblyName(assemblyName);

            // Look for the type
            string? appsettingsReaderTypeName = Configuration["DataReader:ReaderType"];
            
            Type readerType = readerAssembly.ExportedTypes
                                .First(t => t.FullName == appsettingsReaderTypeName);
            //readerType.FullName == "VehicleReader.CSV.CSVReader"


            //funkar inte, blir null pga den tycker inte det skapade objektet är en IVehicleReader
            //reader = Activator.CreateInstance(readerType) as IVehicleReader;

            //funkar inte heller:
            reader = Activator.CreateInstance(readerAssembly.GetType(readerType.FullName!)!) as IVehicleReader;

            //funkar men är ju inte dynamiskt. Väljer vi detta får vi köra en switch/if kring vad vi har i appsettings.json för vilken ReaderType vi vill skapa här (det blir då hårdkodat vilka olika readers som finns)
            //if (appsettingsReaderTypeName == "VehicleReader.CSV.CSVReader")
            //    reader = Activator.CreateInstance(typeof(CSVReader)) as IVehicleReader;
            //OBS att: typeof(CSVReader).FullName == "VehicleReader.CSV.CSVReader"(alltså exakt samma som i exemplet ovan som inte funkar)

            if (reader is null)
            {
                throw new InvalidOperationException(
                    $"Unable to create instance of {readerType} as IVehicleReader");
            }

            return reader;
        }
    }
}