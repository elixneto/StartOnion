using StartOnion.Camada.CrossCutting.Seguranca;
using System;
using System.Text;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Seguranca
{
    public class GeradorDeSaltTeste
    {
        [Fact]
        public void DeveGerarUmSaltCom12Caracteres()
        {
            var salt = GeradorDeHash.GerarSaltEmBytes(12);

            Assert.Equal(12, salt.Length);
        }
    }
}
