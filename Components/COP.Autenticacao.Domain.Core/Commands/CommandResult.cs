using COP.Autenticacao.Domain.Core.NotificationsAutenticacao;
using Flunt.Notifications;
using System.Text.Json.Serialization;

namespace COP.Autenticacao.Domain.Core.Commands
{
    public class CommandResult : NotifiableAutenticacao
    {
        public CommandResult(int statusCode)
        {
            StatusCode = statusCode;
        }

        public CommandResult(int statusCode, string property, string message)
        {
            StatusCode = statusCode;
            AddNotification(property, message);
        }

        public CommandResult(int statusCode, Notifiable item)
        {
            StatusCode = statusCode;
            AddNotifications(item);
        }

        [JsonIgnore]
        public int StatusCode { get; set; }
    }
}