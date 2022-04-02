using COP.Autenticacao.Domain.Core.Commands;
using COP.Autenticacao.Domain.Logins.Commads;
using System.Threading.Tasks;

namespace COP.Autenticacao.Domain.Logins.Interfaces.Handlers
{
    public interface IValidarPasswordHandler
    {
        Task<CommandResult> Handle(ValidarPasswordCommand command);
    }
}