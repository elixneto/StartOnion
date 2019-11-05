using FluentValidation;
using StartOnion.Camada.Dominio.Interfaces;

namespace StartOnion.Camada.Dominio.TestesDeUnidade.NullObjects
{
    class ValidadorDeEntidadeNull : ValidadorDeEntidade<EntidadeNull>
    {
        public ValidadorDeEntidadeNull()
        {
            RuleFor(r => r.CampoCustom)
                .NotEmpty().WithMessage("Campo Custom não informado")
                .Equal("Campo Custom").WithMessage("Campo Custom inválido");
        }
    }
}
