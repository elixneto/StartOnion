using FluentValidation;

namespace StartOnion.Camada.Dominio
{
    public abstract class ValidadorDeEntidade<T> : AbstractValidator<T> where T : Entidade { }
}
