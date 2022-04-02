namespace COP.Autenticacao.Domain.Core.NotificationsAutenticacao
{
    public class Notificacao
    {
        public Notificacao(string property, string message)
        {
            Property = property;
            Message = message;
        }

        public string Property { get; set; }

        public string Message { get; set; }
    }
}
