using COP.Autenticacao.Domain.Logins.Commads;
using COP.Autenticacao.Domain.Logins.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace COP.Autenticacao.Tests.Handlers
{
    [TestClass]
    public class ValidarPasswordHandlerTests
    {
        [TestMethod]
        public async Task Handler_ComPassordVazio_DeveRetornarInvalido()
        {
            var _validarPasswordHandler = new ValidarPasswordHandler();

            var result = await _validarPasswordHandler.Handle(new ValidarPasswordCommand() { Password = string.Empty });

            Assert.IsTrue(result.Invalid);
        }

        [TestMethod]
        public async Task Handler_ComPassordInvalido_DeveRetornarInvalido()
        {
            var _validarPasswordHandler = new ValidarPasswordHandler();

            var result = await _validarPasswordHandler.Handle(new ValidarPasswordCommand() { Password = "12345acvbnf" });

            Assert.IsTrue(result.Invalid);
        }

        [TestMethod]
        public async Task Handler_ComPassordValido_DeveRetornarValido()
        {
            var _validarPasswordHandler = new ValidarPasswordHandler();

            var result = await _validarPasswordHandler.Handle(new ValidarPasswordCommand() { Password = "ABCDEFGhijKl1234!@#" });

            Assert.IsTrue(result.Valid);
        }
    }
}