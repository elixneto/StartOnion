using StartOnion.Camada.Dominio;
using StartOnion.Camada.Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace StartOnion.Implementacao.Repositorio.RavenDB
{
    public abstract class RepositorioDeEntidadeRavenDB<TEntity> : IRepositorioDeEntidade<TEntity> where TEntity : Entidade
    {
        public readonly ContextoRepositorioRavenDB _contexto;

        protected RepositorioDeEntidadeRavenDB(ContextoRepositorioRavenDB contexto)
        {
            _contexto = contexto;
        }

        public virtual void Adicionar(TEntity entidade) => _contexto.Sessao.Store(entidade);

        public virtual void Adicionar(ICollection<TEntity> entidades)
        {
            foreach (var entidade in entidades)
                this.Adicionar(entidade);
        }

        public virtual TEntity ObterPorId(Guid id) => _contexto.Sessao.Load<TEntity>(id.ToString());

        public virtual void Remover(TEntity entidade) => _contexto.Sessao.Delete(entidade);

        public virtual void Remover(ICollection<TEntity> entidades)
        {
            foreach (var entidade in entidades)
                this.Remover(entidade);
        }
    }
}
