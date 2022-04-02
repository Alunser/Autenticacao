using COP.Autenticacao.Domain.Core.Commands;
using COP.Autenticacao.Domain.Logins.Commads;
using COP.Autenticacao.Domain.Logins.Commads.Results;
using COP.Autenticacao.Domain.Logins.Interfaces.Handlers;
using System.Net;
using System.Threading.Tasks;

namespace COP.Autenticacao.Domain.Logins.Handlers
{
    public class ValidarPasswordHandler : IValidarPasswordHandler
    {
        public async Task<CommandResult> Handle(ValidarPasswordCommand command)
        {
            var errorResult = new ValidarPasswordCommandResult(HttpStatusCode.UnprocessableEntity.GetHashCode()) { Valido = false };

            if (!command.IsValid())
            {
                errorResult.AddNotifications(command);
                return errorResult;
            }

            var login = new Login(command.Password);

            if (login.Invalid)
            {
                errorResult.AddNotifications(login);
                return errorResult;
            }

            return new ValidarPasswordCommandResult(HttpStatusCode.OK.GetHashCode()) { Valido = true };
        }
    }
}