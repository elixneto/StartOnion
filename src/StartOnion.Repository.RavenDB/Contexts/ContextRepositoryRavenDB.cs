using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace StartOnion.Repository.RavenDB.Contexts
{
    public sealed class ContextRepositoryRavenDB
    {
        public IDocumentSession Session { get; private set; }

        public ContextRepositoryRavenDB(IDocumentStore documentStore)
        {
            Session = documentStore.OpenSession();
        }

        public void Commit() => Session.SaveChanges();

        public void Rollback() => Session.Dispose();
    }
}
