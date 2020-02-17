using FluentValidation;
using StartOnion.Domain;
using StartOnion.Domain.Exceptions;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.Dominio
{
    public class ValueObjectTests
    {
        class MeuObjetoDeValor : ValueObject<MeuObjetoDeValor> { public MeuObjetoDeValor() : base() { } public MeuObjetoDeValor(IValidator validador) : base(validador) { }
            public override int CustomGetHashCode() => 1;
            public override bool CustomEquals(MeuObjetoDeValor outroObjeto) => true;
        }

        [Fact]
        public void DeveLancarExcecaoQuandoNaoInformarOValidador()
        {
            static void actSemConstrutor() => new MeuObjetoDeValor().Validate();
            static void actComConstrutor() => new MeuObjetoDeValor(null).Validate();

            Assert.Throws<ValidatorNotFoundException>(actSemConstrutor);
            Assert.Throws<ValidatorNotFoundException>(actComConstrutor);
        }
    }
}
