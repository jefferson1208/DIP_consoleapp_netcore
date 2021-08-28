using DIP_consoleapp_netcore.App.Interfaces;
using System;

namespace DIP_consoleapp_netcore.App
{
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
            _email.Enviar();

            if (_notificador.VerificarSeHaNotificacao())
            {
                var notificacoes = _notificador.ObterNotificacoes();

                notificacoes.ForEach((n) =>
                {
                    Console.WriteLine($"Notificacao: {n.Mensagem}");
                });
            }
        }
    }
}
