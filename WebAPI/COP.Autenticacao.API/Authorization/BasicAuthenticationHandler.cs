using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace COP.Autenticacao.API.Authorization
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IConfiguration _configuration;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IConfiguration configuration) : base(options, logger, encoder, clock)
        {
            _configuration = configuration;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

                if (authHeader.Scheme != "Basic")
                    return AuthenticateResult.Fail("Invalid Authorization Header");

                if (!ValidarChaveDeAcessoAoMicroServico(authHeader.Parameter))
                    return AuthenticateResult.Fail("Invalid Authorization Header");
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            return AuthenticateResult.Success(GetAuthenticationTicket());
        }

        private bool ValidarChaveDeAcessoAoMicroServico(string chaveDeAcessoAoMicroServico)
        {
            var chave = _configuration.GetValue(typeof(string), "ChaveAcesso", "semchavenoappsettings");

            return chaveDeAcessoAoMicroServico != null && (chaveDeAcessoAoMicroServico.Equals(chave));
        }

        private AuthenticationTicket GetAuthenticationTicket()
        {
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, ""),
                new Claim(ClaimTypes.Name, "")
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            return new AuthenticationTicket(principal, Scheme.Name);
        }
    }
}
