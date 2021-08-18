using DIP_consoleapp_netcore.App.Interfaces;
using DIP_consoleapp_netcore.App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DIP_consoleapp_netcore.App
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;
        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }
        public void AdicionarNotificacao(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool VerificarSeHaNotificacao()
        {
             return _notificacoes.Any();
        }
    }
}
