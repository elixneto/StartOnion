using StartOnion.Camada.Aplicacao.VMs;
using System.Collections.Generic;

namespace StartOnion.Camada.Aplicacao.Consultas
{
    public class ResultadoDeConsulta<T> where T: VM
    {
        public int QuantidadeTotalDeRegistros { get; }
        public IEnumerable<T> Registros { get; }

        public ResultadoDeConsulta(int quantidadeTotal, IEnumerable<T> registros)
        {
            QuantidadeTotalDeRegistros = quantidadeTotal;
            Registros = registros;
        }
    }
}
