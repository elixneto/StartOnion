using FluentValidation;
using StartOnion.Camada.Dominio.TestesDeUnidade.NullObjects;
using Xunit;

namespace StartOnion.Camada.Dominio.TestesDeUnidade
{
    public class ValidadorDeEntidadeTeste
    {
        private readonly Validador<EntidadeNull> _validador = new ValidadorDeEntidadeNull();

        [Fact]
        public void ValidadorDeveSerUmIValidator()
        {
            Assert.IsAssignableFrom<IValidator>(_validador);
        }
    }
}
