using COP.Autenticacao.Domain.Core.Commands;
using COP.Autenticacao.Domain.Core.Constants;

namespace COP.Autenticacao.Domain.Logins.Commads
{
    public class ValidarPasswordCommand : Command
    {
        public string Password { get; set; }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Password))
                AddNotification("Password", Mensagens.PassordVazio);

            return Valid;
        }
    }
}
