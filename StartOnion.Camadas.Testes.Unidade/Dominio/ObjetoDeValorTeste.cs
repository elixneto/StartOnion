using FluentValidation;
using StartOnion.Camada.Dominio;
using StartOnion.Camada.Dominio.Exceptions;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.Dominio
{
    public class ObjetoDeValorTeste
    {
        class MeuObjetoDeValor : ObjetoDeValor<MeuObjetoDeValor> { public MeuObjetoDeValor() : base() { } public MeuObjetoDeValor(IValidator validador) : base(validador) { }
            public override int ObterHashCode() => 1;
            public override bool PropriedadesIguais(MeuObjetoDeValor outroObjeto) => true;
        }

        [Fact]
        public void DeveLancarExcecaoQuandoNaoInformarOValidador()
        {
            static void actSemConstrutor() => new MeuObjetoDeValor().Validar();
            static void actComConstrutor() => new MeuObjetoDeValor(null).Validar();

            Assert.Throws<ValidadorNaoInformadoException>(actSemConstrutor);
            Assert.Throws<ValidadorNaoInformadoException>(actComConstrutor);
        }
    }
}
