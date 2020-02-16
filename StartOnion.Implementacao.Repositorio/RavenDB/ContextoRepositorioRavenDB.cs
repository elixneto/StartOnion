using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace StartOnion.Implementacao.Repositorio.RavenDB
{
    public sealed class ContextoRepositorioRavenDB
    {
        public IDocumentSession Sessao { get; private set; }

        public ContextoRepositorioRavenDB(IDocumentStore documentStore)
        {
            this.Sessao = documentStore.OpenSession();
        }

        public void Commit() => this.Sessao.SaveChanges();

        public void Rollback() => this.Sessao.Dispose();
    }
}
