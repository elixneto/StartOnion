using FluentValidation;
using System;
using System.Linq.Expressions;

namespace StartOnion.Camada.Dominio
{
    public abstract class Validador<T> : AbstractValidator<T>
    {
        // Expondo o método de adicionar regra do FluentValidation
        public new IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression) =>
            base.RuleFor(expression);
    }
}
