using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace StartOnion.Repository.RavenDB.Contexts
{
    public sealed class ContextQueryRavenDB
    {
        public IAsyncDocumentSession Session { get; }

        public ContextQueryRavenDB(IDocumentStore documentStore)
        {
            Session = documentStore.OpenAsyncSession();
        }
    }
}
