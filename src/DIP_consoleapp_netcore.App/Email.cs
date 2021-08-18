using DIP_consoleapp_netcore.App.Interfaces;
using DIP_consoleapp_netcore.App.Models;

namespace DIP_consoleapp_netcore.App
{
    public class Email : IEmail
    {
        private readonly INotificador _notificador;

        public Email(INotificador notificador)
        {
            _notificador = notificador;
        }

        public void Enviar()
        {
            _notificador.AdicionarNotificacao(new Notificacao("Email enviado com sucesso!"));
        }
    }
}
