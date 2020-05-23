using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System.Threading.Tasks;

namespace StartOnion.Repository.RavenDB.Contexts
{
    public sealed class ContextRepositoryRavenDBAsync
    {
        public IAsyncDocumentSession Session { get; private set; }

        public ContextRepositoryRavenDBAsync(IDocumentStore documentStore)
        {
            Session = documentStore.OpenAsyncSession();
        }

        public async Task Commit() => await Session.SaveChangesAsync();

        public void Rollback() => Session.Dispose();
    }
}
