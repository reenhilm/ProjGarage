using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProjGarage
{
    public class Startup
    {
        private IConfiguration configuration;
        public Startup()
        {
            configuration = GetConfig();
        }
        internal void Setup()
        {
            var ServiceCollection = new ServiceCollection();
            ConfigureServices(ServiceCollection);

            IServiceProvider serviceProvider = ServiceCollection.BuildServiceProvider();
            serviceProvider.GetRequiredService<Manager>().Start();

            IConfiguration config = serviceProvider.GetRequiredService<IConfiguration>();
        }
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(configuration);
            services.AddSingleton<IUI, ConsoleUI>();
            services.AddSingleton<Manager>();
        }
        private IConfiguration GetConfig() => new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();        
    }
}