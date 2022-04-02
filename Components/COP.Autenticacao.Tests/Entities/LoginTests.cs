using COP.Autenticacao.Domain.Core.Constants;
using COP.Autenticacao.Domain.Logins;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace COP.Autenticacao.Tests.Entities
{
    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void Password_ComTamanhoInvalido_DeveRetornarInvalido()
        {
            var login = new Login("ab");
            Assert.IsTrue(login.Notifications.Any(x => x.Message == Mensagens.PasswordComTamanhoInvalido));
        }

        [TestMethod]
        public void Password_SemCaracterMinusculo_DeveRetornarInvalido()
        {
            var login = new Login("ABCDEFG123!@#$%");
            Assert.IsTrue(login.Notifications.Any(x => x.Message == Mensagens.PasswordSemCaracterMinusculo));
        }

        [TestMethod]
        public void Password_SemCaracterMaiusculo_DeveRetornarInvalido()
        {
            var login = new Login("abcdefg123!@#$%");
            Assert.IsTrue(login.Notifications.Any(x => x.Message == Mensagens.PasswordSemCaracterMaiusculo));
        }

        [TestMethod]
        public void Password_SemCaracterNumerico_DeveRetornarInvalido()
        {
            var login = new Login("ABCDEFGH!@#$%");
            Assert.IsTrue(login.Notifications.Any(x => x.Message == Mensagens.PasswordSemCaracterNumerico));
        }

        [TestMethod]
        public void Password_SemCaracterEspecial_DeveRetornarInvalido()
        {
            var login = new Login("ABCDEFG123456");
            Assert.IsTrue(login.Notifications.Any(x => x.Message == Mensagens.PasswordSemCaracterEspecial));
        }

        [TestMethod]
        public void Password_ComCaracterRepetido_DeveRetornarInvalido()
        {
            var login = new Login("AbTp9!foo");
            Assert.IsTrue(login.Notifications.Any(x => x.Message == Mensagens.PasswordComCaracterRepetido));
        }

        [TestMethod]
        public void Password_ComCaracteresEmBranco_DeveRetornarInvalido()
        {
            var login = new Login(" ");
            Assert.IsTrue(login.Notifications.Any(x => x.Message == Mensagens.PasswordComCaracterEmBranco));
        }

        [TestMethod]
        public void Password_Valido_DeveRetornarValido()
        {
            var login = new Login("AbTp9!fok");
            Assert.IsTrue(login.Valid);
        }
    }
}