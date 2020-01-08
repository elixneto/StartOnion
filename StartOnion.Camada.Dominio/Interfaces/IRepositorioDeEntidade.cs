using System.Collections.Generic;

namespace StartOnion.Camada.Dominio.Interfaces
{
    public interface IRepositorioDeEntidade<TEntity>
    {
        TEntity ObterPorId(string id);
        void Adicionar(TEntity entidade);
        void Adicionar(ICollection<TEntity> entidades);
        void Remover(TEntity entidade);
        void Remover(ICollection<TEntity> entidades);
    }
}
