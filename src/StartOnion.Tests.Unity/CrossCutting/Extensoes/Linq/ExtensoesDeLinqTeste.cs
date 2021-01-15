using StartOnion.CrossCutting.Extensions.Linq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Extensoes.Linq
{
    public class ExtensoesDeLinqTeste
    {
        private readonly IQueryable<string> query = new List<string>
            { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Z" }
            .AsQueryable();

        [Fact]
        public void DevePaginarCorretamenteUmaQueryLinq()
        {
            var resultado = query.Paginate(1, 5);

            Assert.Equal(new List<string> { "A", "B", "C", "D", "E" }, resultado.ToList());
        }
    }
}
