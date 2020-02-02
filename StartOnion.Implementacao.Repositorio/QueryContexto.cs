using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace StartOnion.Implementacao.Repositorio
{
    public sealed class QueryContexto
    {
        public readonly IAsyncDocumentSession Sessao;

        public QueryContexto(IDocumentStore documentStore)
        {
            this.Sessao = documentStore.OpenAsyncSession();
        }
    }
}
