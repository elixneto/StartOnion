using System;

namespace StartOnion.InjecaoDeDependencia.Exceptions
{
    public class UrlDoBancoDeDadosNaoInformadoException : Exception
    {
        public UrlDoBancoDeDadosNaoInformadoException()
            : base("em AddStartOnionRepositorio: atribua um valor à propriedade UrlDoBanco -> ConfiguracoesDoBancoDeDados.")
        {

        }
    }
}
