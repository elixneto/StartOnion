using System;

namespace StartOnion.InjecaoDeDependencia.Exceptions
{
    public class NomeDoBancoDeDadosNaoInformadoException : Exception
    {
        public NomeDoBancoDeDadosNaoInformadoException()
            : base("em AddStartOnionRepositorio: atribua um valor à propriedade NomeDoBanco -> ConfiguracoesDoBancoDeDados.")
        {

        }
    }
}
