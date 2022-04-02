using Flunt.Notifications;

namespace COP.Autenticacao.Domain.Core.Commands
{
    public abstract class Command : Notifiable
    {
        public abstract bool IsValid();
    }
}