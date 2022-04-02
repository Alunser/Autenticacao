using COP.Autenticacao.Domain.Core.Commands;

namespace COP.Autenticacao.Domain.Logins.Commads.Results
{
    public class ValidarPasswordCommandResult : CommandResult
    {
        public ValidarPasswordCommandResult(int statusCode) : base(statusCode)
        {
        }

        public bool Valido { get; set; }
    }
}
