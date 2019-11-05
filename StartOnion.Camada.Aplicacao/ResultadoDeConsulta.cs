using System.Collections.Generic;

namespace StartOnion.Camada.Aplicacao
{
    public class ResultadoDeConsulta
    {
        public IEnumerable<VM> Registros { get; set; }
        public int QuantidadeTotalDeRegistros { get; set; }
    }
}
