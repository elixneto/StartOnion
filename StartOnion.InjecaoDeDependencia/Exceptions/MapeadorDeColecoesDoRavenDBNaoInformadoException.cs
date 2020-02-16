using System;

namespace StartOnion.InjecaoDeDependencia.Exceptions
{
    public class MapeadorDeColecoesDoRavenDBNaoInformadoException : Exception
    {
        public MapeadorDeColecoesDoRavenDBNaoInformadoException()
            : base("em AddStartOnionRepositorio: RavenDB foi selecionado, porém não foi encontrado o mapeador de coleções. Por favor, atribuir valor à propriedade MapeadorDeColecoesRavenDB da classe ConfiguracoesDoBancoDeDados.")
        {

        }
    }
}
