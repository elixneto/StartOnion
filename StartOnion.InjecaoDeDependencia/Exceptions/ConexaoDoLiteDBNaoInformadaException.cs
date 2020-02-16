using System;

namespace StartOnion.InjecaoDeDependencia.Exceptions
{
    public class ConexaoDoLiteDBNaoInformadaException : Exception
    {
        public ConexaoDoLiteDBNaoInformadaException()
            : base("em AddStartOnionRepositorio: LiteDB foi selecionado, porém não foi encontrada sua conexão. Por favor, atribuir valor à propriedade ConexaoLiteDB da classe ConfiguracoesDoBancoDeDados.")
        {

        }
    }
}
