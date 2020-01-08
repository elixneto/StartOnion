using StartOnion.Camada.Dominio.Interfaces;
using System.Collections.Generic;

namespace StartOnion.Implementacao.Repositorio
{
    public abstract class RepositorioDeEntidade<TEntity> : IRepositorioDeEntidade<TEntity>
    {
        public readonly ContextoDoBancoDeDados _contexto;

        protected RepositorioDeEntidade(ContextoDoBancoDeDados contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(TEntity entidade) => _contexto.Sessao.Store(entidade);

        public void Adicionar(ICollection<TEntity> entidades)
        {
            foreach (var entidade in entidades)
                this.Adicionar(entidade);
        }

        public TEntity ObterPorId(string id) => _contexto.Sessao.Load<TEntity>(id);

        public void Remover(TEntity entidade) => _contexto.Sessao.Delete(entidade);

        public void Remover(ICollection<TEntity> entidades)
        {
            foreach (var entidade in entidades)
                this.Remover(entidade);
        }
    }
}
