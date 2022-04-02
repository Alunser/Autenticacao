using COP.Autenticacao.Domain.Core.Constants;
using COP.Autenticacao.Domain.Core.Entities;
using COP.Autenticacao.Domain.Core.Extensions;
using System;

namespace COP.Autenticacao.Domain.Logins
{
    public class Login : Entity
    {
        #region Construtores

        public Login(string password)
        {
            DefinirPassword(password);  
        }

        #endregion

        #region Propriedades

        public string Password { get; private set; }

        #endregion

        #region Métods

        public void DefinirPassword(string password)
        {
            if (password.Length < 9)
                AddNotification("Password", Mensagens.PasswordComTamanhoInvalido);

            if (!password.ContainsNumber())
                AddNotification("Password", Mensagens.PasswordSemCaracterNumerico);

            if (!password.ContainsLowercase())
                AddNotification("Password", Mensagens.PasswordSemCaracterMinusculo);

            if (!password.ContainsUppercase())
                AddNotification("Password", Mensagens.PasswordSemCaracterMaiusculo);

            if (!password.ContainsSpecialCharacter())
                AddNotification("Password", Mensagens.PasswordSemCaracterEspecial);

            if (password.ContainsRepeatedCharacter())
                AddNotification("Password", Mensagens.PasswordComCaracterRepetido);

            if (password.ContainsWhiteSpace())
                AddNotification("Password", Mensagens.PasswordComCaracterEmBranco);

            if (Valid)
                Password = password;
        }

        #endregion
    }
}