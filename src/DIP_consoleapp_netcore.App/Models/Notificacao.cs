namespace DIP_consoleapp_netcore.App.Models
{
    public class Notificacao
    {
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; private set; }
    }
}
