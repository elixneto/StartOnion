using FluentValidation;
using StartOnion.Domain;
using StartOnion.Domain.Exceptions;
using System;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.Dominio
{
    public class EntityTests
    {
        class MinhaEntidade : Entity { public MinhaEntidade() : base() { } public MinhaEntidade(Guid id) : base(id) { } public MinhaEntidade(IValidator validador) : base(validador) { } }

        [Fact]
        public void DeveGerarIdComoGuid()
        {
            var id = new MinhaEntidade().Id;

            Assert.True(id.GetType().IsAssignableFrom(typeof(Guid)));
        }

        [Fact]
        public void DeveLancarExcecaoQuandoNaoInformarOValidador()
        {
            static void actSemConstrutor() => new MinhaEntidade().Validate();
            static void actComConstrutor() => new MinhaEntidade(null).Validate();

            Assert.Throws<ValidatorNotFoundException>(actSemConstrutor);
            Assert.Throws<ValidatorNotFoundException>(actComConstrutor);
        }

        [Fact]
        public void DeveGerarUmNovoGuidSempreQueInstanciarUmaNovaClasse()
        {
            var minhaEntidade = new MinhaEntidade();

            Assert.False(minhaEntidade.Id == default);
        }

        [Fact]
        public void DeveAlterarOId()
        {
            var guidEsperado = new Guid("ba9c480a-6370-415e-adf7-20cb715ba9b6");

            var minhaEntidade = new MinhaEntidade(guidEsperado);

            Assert.Equal(guidEsperado, minhaEntidade.Id);
        }
    }
}
