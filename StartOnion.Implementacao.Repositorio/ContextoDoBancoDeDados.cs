using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace StartOnion.Implementacao.Repositorio
{
    public sealed class ContextoDoBancoDeDados
    {
        public readonly IDocumentSession Sessao;

        public ContextoDoBancoDeDados(IDocumentStore documentStore)
        {
            this.Sessao = documentStore.OpenSession();
        }

        public void Commit() => this.Sessao.SaveChanges();
        public void Rollback() => this.Sessao.Dispose();
    }
}
