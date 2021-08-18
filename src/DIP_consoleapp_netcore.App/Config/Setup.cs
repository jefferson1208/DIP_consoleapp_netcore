using DIP_consoleapp_netcore.App.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DIP_consoleapp_netcore.App.Config
{
    public static class Setup
    {
        public static void ConfigServices(this IServiceCollection services)
        {
            services.AddSingleton<App>();
            services.AddSingleton<INotificador, Notificador>();
            services.AddSingleton<IEmail, Email>();
        }
    }
}
