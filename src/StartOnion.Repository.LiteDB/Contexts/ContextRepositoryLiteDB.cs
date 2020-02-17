using LiteDB;
using StartOnion.Repository.LiteDB.Configurations;

namespace StartOnion.Repository.LiteDB.Contexts
{
    public sealed class ContextRepositoryLiteDB
    {
        private readonly ConfigLiteDB _configuracao;
        public LiteDatabase Sessao { get; private set; }

        public ContextRepositoryLiteDB(ConfigLiteDB configuracao)
        {
            _configuracao = configuracao;
        }

        public void OpenSession()
        {
            Sessao = new LiteDatabase(_configuracao.PathDB);
            Sessao.BeginTrans();
        }

        public void Commit() => this.Sessao.Commit();

        public void Rollback() => this.Sessao.Rollback();

        public void Dispose() => this.Sessao.Dispose();
    }
}
