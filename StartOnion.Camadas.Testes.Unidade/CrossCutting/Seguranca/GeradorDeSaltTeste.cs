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
            var salt = GeradorDeHash.GerarSalt(12);

            Assert.Equal(12, salt.Length);
        }

        [Fact]
        public void DeveGerarUmHashComSaltSHA256()
        {
            byte[] salt = Encoding.UTF8.GetBytes("lCxaRpEHMvX2");
            byte[] texto = Encoding.UTF8.GetBytes("minhasenha");

            var hashEmStringBase64 = Convert.ToBase64String(GeradorDeHash.GerarSaltedHashSHA256(texto, salt));

            Assert.Equal("1MzNa+nwOp51muEDbaHd0zOyAQkFEnV0aAD4CgxN2oU=", hashEmStringBase64);
        }
    }
}
