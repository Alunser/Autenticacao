using COP.Autenticacao.Domain.Logins.Commads;
using COP.Autenticacao.Domain.Logins.Commads.Results;
using COP.Autenticacao.Domain.Logins.Interfaces.Handlers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Threading.Tasks;

namespace COP.Autenticacao.API.Controllers
{
    [Route("v1/login")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly IValidarPasswordHandler _validarPasswordHandler;
        public LoginController(IValidarPasswordHandler validarPasswordHandler) : base()
        {
            _validarPasswordHandler = validarPasswordHandler;
        }

        /// <summary>
        /// Endpoint de validação de um password
        /// </summary>
        /// <param name="password">Senha do usuário</param>
        /// <returns></returns>
        [HttpPost("")]
        [SwaggerOperation(Tags = new[] { "Login" })]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ValidarPasswordCommandResult))]
        public async Task<IActionResult> Post(string password)
        {
            return Result(await _validarPasswordHandler.Handle(new ValidarPasswordCommand() { Password = password }));
        }
    }
}