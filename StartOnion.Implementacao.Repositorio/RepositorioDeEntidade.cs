using StartOnion.Camada.Dominio.Interfaces;
using System.Collections.Generic;

namespace StartOnion.Implementacao.Repositorio
{
    public abstract class RepositorioDeEntidade<T> : IRepositorioDeEntidade<T>
    {
        public readonly ContextoDoBancoDeDados _contexto;

        public RepositorioDeEntidade(ContextoDoBancoDeDados contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(T entidade) => _contexto.Sessao.Store(entidade);

        public void Adicionar(ICollection<T> entidades)
        {
            foreach (var entidade in entidades)
                this.Adicionar(entidade);
        }

        public void Atualizar(T entidade)
        {
            throw new System.NotImplementedException();
        }

        public T ObterPorId(string id) => _contexto.Sessao.Load<T>(id);

        public void Remover(T entidade) => _contexto.Sessao.Delete(entidade);

        public void Remover(ICollection<T> entidades)
        {
            foreach (var entidade in entidades)
                this.Remover(entidade);
        }
    }
}
