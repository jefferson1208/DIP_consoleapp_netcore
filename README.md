# Utilizando Injeção de Dependência em Aplicações Console
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## 1 - Pacotes

```bash
Install-Package Microsoft.Extensions.DependencyInjection -version 3.1.1
Install-Package Microsoft.Extensions.DependencyInjection.Abstractions -version 3.1.1

```

## 2 - Configuração dos serviços

Extenda a interface IServiceCollection, conforme sua necessidade. Exemplo:
```csharp
public static class Setup
    {
        public static void ConfigServices(this IServiceCollection services)
        {
            services.AddSingleton<App>();
            services.AddSingleton<INotificador, Notificador>();
            services.AddSingleton<IEmail, Email>();
        }
    }
```

## 3 - Inicialização do programa

Crie uma classe que será a porta de entrada da sua aplicação. Esta classe já pode receber injeções conforme configuração no método acima. Exemplo:
```csharp
public class App
    {
        private readonly INotificador _notificador;
        private readonly IEmail _email;

        public App(INotificador notificador, IEmail email)
        {
            _notificador = notificador;
            _email = email;
        }
        public void Iniciar()
        {
            //aqui é o start da sua aplicação
        }
    }
```

## 4 - Classe Program

Esta classe passa a servir apenas como configuração da inicialização da sua aplicação. Exemplo:
```csharp
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
```


## 5 - Concluíndo
Tudo certo. Agora qualquer serviço que precise utilizar na sua aplicação, basta registrá-lo na <b>Setup</b> (Item 2).
