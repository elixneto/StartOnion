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

            Assert.True(Guid.TryParse(id, out _));
        }

        [Fact]
        public void DeveLancarExcecaoQuandoNaoInformarOValidador()
        {
            static void actSemConstrutor() => new MinhaEntidade().Validar();
            static void actComConstrutor() => new MinhaEntidade(null).Validar();

            Assert.Throws<ValidadorNaoInformadoException>(actSemConstrutor);
            Assert.Throws<ValidadorNaoInformadoException>(actComConstrutor);
        }
    }
}
