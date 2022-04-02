using COP.Autenticacao.API.Controllers;
using COP.Autenticacao.Domain.Logins.Commads;
using COP.Autenticacao.Domain.Logins.Commads.Results;
using COP.Autenticacao.Domain.Logins.Interfaces.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Threading.Tasks;

namespace COP.Autenticacao.Tests.Controllers
{
    [TestClass]
    public class LoginControllerTests
    {
        [TestMethod]
        public async Task LoginController_Post_ComPassordVazio_DeveRetornarInvalido()
        {
            Mock<IValidarPasswordHandler> _handlerMock = new Mock<IValidarPasswordHandler>();
            _handlerMock.Setup(_ => _.Handle(It.IsAny<ValidarPasswordCommand>()))
                .ReturnsAsync(new ValidarPasswordCommandResult(HttpStatusCode.UnprocessableEntity.GetHashCode()) { Valido = false });

            var loginController = new LoginController(_handlerMock.Object);

            IActionResult controller = await loginController.Post(" ");

            var contentResult = ((ObjectResult)controller).Value;
            var response = (ValidarPasswordCommandResult)contentResult;

            Assert.IsTrue(!response.Valido && response.StatusCode == HttpStatusCode.UnprocessableEntity.GetHashCode());
        }

        [TestMethod]
        public async Task LoginController_Post_ComPassordInvalido_DeveRetornarInvalido()
        {
            Mock<IValidarPasswordHandler> _handlerMock = new Mock<IValidarPasswordHandler>();
            _handlerMock.Setup(_ => _.Handle(It.IsAny<ValidarPasswordCommand>()))
                .ReturnsAsync(new ValidarPasswordCommandResult(HttpStatusCode.UnprocessableEntity.GetHashCode()) { Valido = false });

            var loginController = new LoginController(_handlerMock.Object);

            IActionResult controller = await loginController.Post("AbTp9!foo");

            var contentResult = ((ObjectResult)controller).Value;
            var response = (ValidarPasswordCommandResult)contentResult;

            Assert.IsTrue(!response.Valido && response.StatusCode == HttpStatusCode.UnprocessableEntity.GetHashCode());
        }

        [TestMethod]
        public async Task LoginController_Post_ComPassorValido_DeveRetornarValido()
        {
            Mock<IValidarPasswordHandler> _handlerMock = new Mock<IValidarPasswordHandler>();
            _handlerMock.Setup(_ => _.Handle(It.IsAny<ValidarPasswordCommand>()))
                .ReturnsAsync(new ValidarPasswordCommandResult(HttpStatusCode.OK.GetHashCode()) { Valido = true });

            var loginController = new LoginController(_handlerMock.Object);

            IActionResult controller = await loginController.Post("AbTp9!fok");

            var contentResult = ((ObjectResult)controller).Value;
            var response = (ValidarPasswordCommandResult)contentResult;

            Assert.IsTrue(response.Valido && response.StatusCode == HttpStatusCode.OK.GetHashCode());
        }
    }
}
