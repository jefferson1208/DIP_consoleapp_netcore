using DIP_consoleapp_netcore.App.Config;
using DIP_consoleapp_netcore.App.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DIP_consoleapp_netcore.App
{
    class Program
    {

        static void Main(string[] args)
        {
            var host = CreateHost(args).Build();
            host.Services.GetRequiredService<IApp>().Iniciar();


        }
        private static IHostBuilder CreateHost(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.ConfigServices();
                });
        }
    }
}
