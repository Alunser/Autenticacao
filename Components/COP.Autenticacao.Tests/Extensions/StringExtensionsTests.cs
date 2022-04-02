using COP.Autenticacao.Domain.Core.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace COP.Autenticacao.Tests.Extensions
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void String_ComCaracterEmBranco_DeveRetornarInvalido()
        {
            var texto = " ";
            Assert.IsTrue(texto.ContainsWhiteSpace());
        }

        [TestMethod]
        public void String_SemCaracterNumerico_DeveRetornarInvalido()
        {
            var texto = "acbdecds";
            Assert.IsTrue(!texto.ContainsNumber());
        }

        [TestMethod]
        public void String_SemCaracterMinusculo_DeveRetornarInvalido()
        {
            var texto = "ASDCEDFFD1234";
            Assert.IsTrue(!texto.ContainsLowercase());
        }

        [TestMethod]
        public void String_SemCaracterMaiusculo_DeveRetornarInvalido()
        {
            var texto = "asdcedffd1234";
            Assert.IsTrue(!texto.ContainsUppercase());
        }

        [TestMethod]
        public void String_SemCaracterEspecial_DeveRetornarInvalido()
        {
            var texto = "asdcedffd1234";
            Assert.IsTrue(!texto.ContainsSpecialCharacter());
        }

        [TestMethod]
        public void String_ComCaracterRepetido_DeveRetornarInvalido()
        {
            var texto = "AAaabcdefghij!@@#$";
            Assert.IsTrue(texto.ContainsUppercase());
        }

        [TestMethod]
        public void String_SemCaracterEmBranco_DeveRetornarValido()
        {
            var texto = "";
            Assert.IsTrue(!texto.ContainsWhiteSpace());
        }

        [TestMethod]
        public void String_ComCaracterNumerico_DeveRetornarValido()
        {
            var texto = "ABdsdf123";
            Assert.IsTrue(texto.ContainsNumber());
        }

        [TestMethod]
        public void String_ComCaracterMinusculo_DeveRetornarValido()
        {
            var texto = "aSDCEDFFD1234";
            Assert.IsTrue(texto.ContainsLowercase());
        }

        [TestMethod]
        public void String_ComCaracterMaiusculo_DeveRetornarValido()
        {
            var texto = "Asdcedffd1234";
            Assert.IsTrue(texto.ContainsUppercase());
        }

        [TestMethod]
        public void String_ComCaracterEspecial_DeveRetornarValido()
        {
            var texto = "Asdcedffd1234!@#";
            Assert.IsTrue(texto.ContainsUppercase());
        }

        [TestMethod]
        public void String_SemCaracterRepetido_DeveRetornarValido()
        {
            var texto = "abcdefghij!@#$";
            Assert.IsTrue(!texto.ContainsRepeatedCharacter());
        }
    }
}