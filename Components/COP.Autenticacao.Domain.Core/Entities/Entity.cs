using COP.Autenticacao.Domain.Core.NotificationsAutenticacao;
using System;

namespace COP.Autenticacao.Domain.Core.Entities
{
    public abstract class Entity : NotifiableAutenticacao
    {
        #region Construtores  
        
        protected Entity()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            Ativo = true;
        }

        #endregion

        #region Atributos 
        
        public Guid Id { get; protected set; }
        public DateTime DataCriacao { get; protected set; }
        public DateTime? DataAlteracao { get; protected set; }
        public bool Ativo { get; protected set; }
        #endregion

        #region Métodos e comportamentos    
        
        public void DefinirId(Guid id)
        {
            Id = id;
        }

        public void DefinirDataAlteracao()
        {
            DataAlteracao = DateTime.Now;
        }

        public void Ativar()
        {
            Ativo = true;
            DataAlteracao = DateTime.Now;
        }

        public void Inativar()
        {
            Ativo = false;
            DataAlteracao = DateTime.Now;
        }

        #endregion
    }
}
