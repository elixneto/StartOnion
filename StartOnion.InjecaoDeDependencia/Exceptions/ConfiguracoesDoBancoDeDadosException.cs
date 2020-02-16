using System;

namespace StartOnion.InjecaoDeDependencia.Exceptions
{
    public class ConfiguracoesDoBancoDeDadosException : Exception
    {
        public ConfiguracoesDoBancoDeDadosException()
            : base("em AddStartOnionRepositorio: atribua um valor -> ConfiguracoesDoBancoDeDados.")
        {

        }
    }
}
