using DIP_consoleapp_netcore.App.Config;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIP_consoleapp_netcore.App
{
    class Program
    {
        private readonly IServiceCollection _services;
        private IServiceProvider _provider;
        private App _app;
        public Program()
        {
            _services = new ServiceCollection();
        }
        static void Main(string[] args)
        {
            new Program().IniciarPrograma();
        }

        private void IniciarPrograma()
        {
            Config();

            _app.Iniciar();
        }
        private void Config()
        {
            _services.ConfigServices();
            _provider = _services.BuildServiceProvider();

            _app = _provider.GetService<App>();
        }
    }
}
