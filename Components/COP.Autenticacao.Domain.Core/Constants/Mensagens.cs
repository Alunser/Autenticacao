namespace COP.Autenticacao.Domain.Core.Constants
{
    public static class Mensagens
    {
        public const string PassordVazio = "Password inválido.";

        public const string PasswordComTamanhoInvalido = "Password deve conter pelo menos 9 caracteres.";
        public const string PasswordComCaracterRepetido = "Password não deve conter caracteres repetidos.";
        public const string PasswordComCaracterEmBranco = "Password não deve conter caracteres brancos.";

        public const string PasswordSemCaracterTexto = "Password deve conter 1 letra.";
        public const string PasswordSemCaracterNumerico = "Password deve conter 1 número.";
        public const string PasswordSemCaracterMaiusculo = "Password deve conter 1 caracter maiúsculo.";
        public const string PasswordSemCaracterMinusculo = "Password deve conter 1 caracter minúsculo.";
        public const string PasswordSemCaracterEspecial = "Password deve conter 1 caracter especial.";
    }
}