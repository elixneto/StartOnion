using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace StartOnion.Implementacao.Repositorio
{
    public sealed class BancoDeDadosContexto
    {
        public readonly IDocumentSession Sessao;

        public BancoDeDadosContexto(IDocumentStore documentStore)
        {
            this.Sessao = documentStore.OpenSession();
        }

        public void Commit() => this.Sessao.SaveChanges();
        public void Rollback() => this.Sessao.Dispose();
    }
}
