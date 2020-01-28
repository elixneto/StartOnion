using System;

namespace StartOnion.Camada.Dominio.Exceptions
{
    public class ValidadorNaoInformadoException : Exception
    {
        public ValidadorNaoInformadoException() : base("O validador não foi informado na classe implementada. Use o construtor que informa o validador.")
        {

        }
    }
}
