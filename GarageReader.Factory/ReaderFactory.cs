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


            //note: this one requires copy local: no    ... on the readers interface-project-reference
            reader = Activator.CreateInstance(readerType) as IVehicleReader;

            if (reader is null)
            {
                throw new InvalidOperationException(
                    $"Unable to create instance of {readerType} as IVehicleReader");
            }

            return reader;
        }
    }
}