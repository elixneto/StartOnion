using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace StartOnion.Camada.CrossCutting.Notificacoes
{
    public abstract class Notificavel
    {
        private readonly IList<string> _notificacoes = new List<string>();

        protected void AdicionarNotificacao(string notificacao) => _notificacoes.Add(notificacao);
        protected void AdicionarNotificacoes(IList<ValidationFailure> erros)
        {
            foreach (var erro in erros)
                this.AdicionarNotificacao(erro.ErrorMessage);
        }

        public bool EhValido() => !_notificacoes.Any();
        public IReadOnlyList<string> ObterNotificacoes() => _notificacoes.ToArray();
    }
}
