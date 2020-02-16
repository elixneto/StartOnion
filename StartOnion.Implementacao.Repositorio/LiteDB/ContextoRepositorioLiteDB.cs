using LiteDB;

namespace StartOnion.Implementacao.Repositorio.LiteDB
{
    public sealed class ContextoRepositorioLiteDB
    {
        private readonly ConfiguracaoLiteDB _configuracao;
        public LiteDatabase Sessao { get; private set; }

        public ContextoRepositorioLiteDB(ConfiguracaoLiteDB configuracao)
        {
            _configuracao = configuracao;
        }

        public void AbrirSessao()
        {
            Sessao = new LiteDatabase(_configuracao.StringDeConexao);
            Sessao.BeginTrans();
        }

        public void Commit() => this.Sessao.Commit();

        public void Rollback() => this.Sessao.Rollback();

        public void Dispose() => this.Sessao.Dispose();
    }
}
