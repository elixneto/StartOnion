using System;
using System.Linq.Expressions;

namespace StartOnion.Camada.CrossCutting.Testes.Extensoes
{
    public static class ExtensaoDePropriedade
    {
        public static void ComValor<T, TT>(this T tipo, Expression<Func<TT>> propriedade, TT novoValor)
        {
            var memberExpression = propriedade.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("Expression deve ser do tipo MemberExpression", "propriedade");

            var nomeDaPropriedade = memberExpression.Member.Name;

            typeof(T).GetProperty(nomeDaPropriedade).SetValue(tipo, novoValor, null);
        }
    }
}
