using DIP_consoleapp_netcore.App.Models;
using System.Collections.Generic;

namespace DIP_consoleapp_netcore.App.Interfaces
{
    public interface INotificador
    {
        bool VerificarSeHaNotificacao();
        void AdicionarNotificacao(Notificacao notificacao);

        List<Notificacao> ObterNotificacoes();
    }
}
