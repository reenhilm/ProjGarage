using Microsoft.Extensions.Configuration;
using VehicleReader.Interface;
using System.Reflection;

namespace VehicleReader.Factory
{
    public class ReaderFactory
    {
        private IConfiguration Configuration;
        public ReaderFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IVehicleReader? reader;

        public IVehicleReader GetReader()
        {
            if (reader != null)
                return reader;

            // Check configuration
            string? readerAssemblyName = Configuration["DataReader:ReaderAssembly"];
            string readerLocation = AppDomain.CurrentDomain.BaseDirectory
                                    + "ReaderAssemblies"
                                    + Path.DirectorySeparatorChar
                                    + readerAssemblyName;

            // Load the assembly
            ReaderLoadContext loadContext = new ReaderLoadContext(readerLocation);
            AssemblyName assemblyName = new AssemblyName(Path.GetFileNameWithoutExtension(readerLocation));
            Assembly readerAssembly = loadContext.LoadFromAssemblyName(assemblyName);

            // Look for the type
            string? readerTypeName = Configuration["DataReader:ReaderType"];
            Type readerType = readerAssembly.ExportedTypes
                                .First(t => t.FullName == readerTypeName);

            // Create the data reader
            reader = Activator.CreateInstance(readerType) as IVehicleReader;
            if (reader is null)
            {
                throw new InvalidOperationException(
                    $"Unable to create instance of {readerType} as IPersonReader");
            }

            // Return the data reader
            return reader;
        }
    }
}