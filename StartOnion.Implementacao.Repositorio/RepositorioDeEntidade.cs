using StartOnion.Camada.Dominio.Interfaces;
using System.Collections.Generic;

namespace StartOnion.Implementacao.Repositorio
{
    public abstract class RepositorioDeEntidade<TEntity> : IRepositorioDeEntidade<TEntity>
    {
        public readonly BancoDeDadosContexto _contexto;

        protected RepositorioDeEntidade(BancoDeDadosContexto contexto)
        {
            _contexto = contexto;
        }

        public virtual void Adicionar(TEntity entidade) => _contexto.Sessao.Store(entidade);

        public virtual void Adicionar(ICollection<TEntity> entidades)
        {
            foreach (var entidade in entidades)
                this.Adicionar(entidade);
        }

        public virtual TEntity ObterPorId(string id) => _contexto.Sessao.Load<TEntity>(id);

        public virtual void Remover(TEntity entidade) => _contexto.Sessao.Delete(entidade);

        public virtual void Remover(ICollection<TEntity> entidades)
        {
            foreach (var entidade in entidades)
                this.Remover(entidade);
        }
    }
}
