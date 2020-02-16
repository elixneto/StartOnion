namespace StartOnion.Implementacao.Repositorio.LiteDB
{
    public class ConfiguracaoLiteDB
    {
        public string StringDeConexao { get; }

        public ConfiguracaoLiteDB(string stringDeConexao)
        {
            StringDeConexao = stringDeConexao;
        }
    }
}
