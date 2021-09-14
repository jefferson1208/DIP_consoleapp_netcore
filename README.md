# Utilizando Injeção de Dependência em Aplicações Console
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## 1 - Pacotes

```bash
Install-Package Microsoft.Extensions.Hosting

```

## 2 - Configuração dos serviços

Extenda a interface IServiceCollection, conforme sua necessidade. Exemplo:
```csharp
public static class Setup
    {
        public static void ConfigServices(this IServiceCollection services)
        {
            services.AddSingleton<IApp, App>();
            services.AddSingleton<INotificador, Notificador>();
            services.AddSingleton<IEmail, Email>();
        }
    }
```

## 3 - Inicialização do programa

Crie uma classe que será a porta de entrada da sua aplicação. Esta classe já pode receber injeções conforme configuração no método acima. Exemplo:
```csharp
public class App : IApp
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
```


## 5 - Concluíndo
Tudo certo 😃. Agora qualquer serviço que precise utilizar na sua aplicação, basta registrá-lo na <b>Setup</b> (Item 2).

## 6 - Tecnologias
<div style="display: inline_block"><br>
  <img align="center" alt="Jeferson-Netcore" height="30" width="40" src="https://github.com/devicons/devicon/blob/master/icons/dotnetcore/dotnetcore-original.svg">
  <img align="center" alt="Jeferson-Csharp" height="30" width="40" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg">
</div>
