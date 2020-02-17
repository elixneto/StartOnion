using CollectionMapper.RavenDB.NetCore;

namespace StartOnion.InjecaoDeDependencia
{
    public sealed class ConfiguracoesDoBancoDeDados
    {
        public bool IsUsingRavenDB { get; private set; } = false;
        public string UrlDoBancoRavenDB { get; private set; }
        public string NomeDoBancoRavenDB { get; private set; }
        public CollectionMapperRavenDB MapeadorDeColecoesRavenDB { get; private set; }
        public void UseRavenDB(string urlDoBanco, string nomeDoBanco, CollectionMapperRavenDB mapeadorDeColecoes)
        {
            IsUsingRavenDB = true;
            UrlDoBancoRavenDB = urlDoBanco;
            NomeDoBancoRavenDB = nomeDoBanco;
            MapeadorDeColecoesRavenDB = mapeadorDeColecoes;
        }

        public bool IsUsingLiteDB { get; private set; } = false;
        public string ConexaoLiteDB { get; private set; }
        public void UseLiteDB(string caminhoDoArquivo)
        {
            IsUsingLiteDB = true;
            ConexaoLiteDB = caminhoDoArquivo;
        }
    }
}
