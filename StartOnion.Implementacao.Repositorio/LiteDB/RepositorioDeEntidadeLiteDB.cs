using LiteDB;
using StartOnion.Camada.Dominio;
using StartOnion.Camada.Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace StartOnion.Implementacao.Repositorio.LiteDB
{
    public abstract class RepositorioDeEntidadeLiteDB<TEntity> : IRepositorioDeEntidade<TEntity> where TEntity : Entidade
    {
        public readonly ContextoRepositorioLiteDB _contexto;

        protected RepositorioDeEntidadeLiteDB(ContextoRepositorioLiteDB contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(TEntity entidade)
            => _contexto.Sessao.GetCollection<TEntity>().Insert(entidade);

        public void Adicionar(ICollection<TEntity> entidades)
            => _contexto.Sessao.GetCollection<TEntity>().InsertBulk(entidades);

        public TEntity ObterPorId(Guid id)
            => _contexto.Sessao.GetCollection<TEntity>().FindById(new BsonValue(id));

        public void Remover(TEntity entidade)
            => _contexto.Sessao.GetCollection<TEntity>().Delete(new BsonValue(entidade.Id));

        public void Remover(ICollection<TEntity> entidades)
        {
            foreach (var entidade in entidades)
                Remover(entidade);
        }
    }
}
