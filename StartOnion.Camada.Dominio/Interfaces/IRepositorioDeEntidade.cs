using System.Collections.Generic;

namespace StartOnion.Camada.Dominio.Interfaces
{
    public interface IRepositorioDeEntidade<T> where T : Entidade
    {
        T ObterPorId(string id);
        void Adicionar(T entidade);
        void Adicionar(ICollection<T> entidades);
        void Atualizar(T entidade);
        void Remover(T entidade);
        void Remover(ICollection<T> entidades);
    }
}
