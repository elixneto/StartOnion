using LiteDB;
using StartOnion.Repository.LiteDB.Configurations;

namespace StartOnion.Repository.LiteDB.Contexts
{
    public sealed class ContextRepositoryLiteDB
    {
        private readonly LiteDBConfiguration _configuration;
        public LiteDatabase Session { get; private set; }

        public ContextRepositoryLiteDB(LiteDBConfiguration configuracao)
        {
            _configuration = configuracao;
        }

        public void OpenSession()
        {
            Session = new LiteDatabase(_configuration.PathDB);
            Session.BeginTrans();
        }

        public void Commit() => this.Session.Commit();

        public void Rollback() => this.Session.Rollback();

        public void Dispose() => this.Session.Dispose();
    }
}
