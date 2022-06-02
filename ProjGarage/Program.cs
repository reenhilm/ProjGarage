using Microsoft.Extensions.DependencyInjection;

void Setup()
{
    var ServiceCollection = new ServiceCollection();
    ConfigureServices(ServiceCollection);

    IServiceProvider serviceProvider = ServiceCollection.BuildServiceProvider();
    serviceProvider.GetRequiredService<Manager>().Start();
}

void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IUI,ConsoleUI>();
    services.AddSingleton<Manager>();
}

Setup();