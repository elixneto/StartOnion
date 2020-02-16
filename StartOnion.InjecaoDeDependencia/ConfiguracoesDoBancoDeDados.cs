using CollectionMapper.RavenDB.NetCore;

namespace StartOnion.InjecaoDeDependencia
{
    public sealed class ConfiguracoesDoBancoDeDados
    {
        public bool UseRavenDB { get; }
        public bool UseLiteDB { get; }
        public string UrlDoBanco { get; set; }
        public string NomeDoBanco { get; set; }

        public CollectionMapperRavenDB MapeadorDeColecoesRavenDB { get; set; }
        public string ConexaoLiteDB { get; set; }

        public ConfiguracoesDoBancoDeDados(bool useRavenDB, bool useLiteDB)
        {
            UseRavenDB = useRavenDB;
            UseLiteDB = useLiteDB;
        }
    }
}
