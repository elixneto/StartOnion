using FluentValidation;
using StartOnion.Camada.Dominio;
using StartOnion.Camada.Dominio.Exceptions;
using System;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.Dominio
{
    public class EntidadeTeste
    {
        class MinhaEntidade : Entidade { public MinhaEntidade() : base() { } public MinhaEntidade(IValidator validador) : base(validador) { } }

        [Fact]
        public void DeveGerarIdComoGuid()
        {
            var id = new MinhaEntidade().Id;

            Assert.True(id.GetType().IsAssignableFrom(typeof(Guid)));
        }

        [Fact]
        public void DeveLancarExcecaoQuandoNaoInformarOValidador()
        {
            static void actSemConstrutor() => new MinhaEntidade().Validar();
            static void actComConstrutor() => new MinhaEntidade(null).Validar();

            Assert.Throws<ValidadorNaoInformadoException>(actSemConstrutor);
            Assert.Throws<ValidadorNaoInformadoException>(actComConstrutor);
        }

        [Fact]
        public void DeveGerarUmNovoGuidSempreQueInstanciarUmaNovaClasse()
        {
            var minhaEntidade = new MinhaEntidade();

            Assert.False(minhaEntidade.Id == default);
        }
    }
}
