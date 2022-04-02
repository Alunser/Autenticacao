using COP.Autenticacao.Domain.Core.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace COP.Autenticacao.API.Controllers
{

    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(string))]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity, Type = typeof(CommandResult))]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult Result(CommandResult result)
        {
            var statusCode = result.StatusCode != 412 ? result.StatusCode : 422;

            if (result.Valid)
                result.Notifications = null;

            return StatusCode(statusCode, result);
        }
    }
}
