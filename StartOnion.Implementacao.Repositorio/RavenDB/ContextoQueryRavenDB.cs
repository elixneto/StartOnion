using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace StartOnion.Implementacao.Repositorio.RavenDB
{
    public sealed class ContextoQueryRavenDB
    {
        public IAsyncDocumentSession Sessao { get; }

        public ContextoQueryRavenDB(IDocumentStore documentStore)
        {
            this.Sessao = documentStore.OpenAsyncSession();
        }
    }
}
