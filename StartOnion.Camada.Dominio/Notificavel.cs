using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace StartOnion.Camada.Dominio
{
    public abstract class Notificavel
    {
        private readonly IList<string> _notificacoes = new List<string>();

        protected void AdicionarNotificacao(string notificacao) => this._notificacoes.Add(notificacao);
        protected void AdicionarNotificacoes(IList<ValidationFailure> erros)
        {
            foreach (var erro in erros)
                this.AdicionarNotificacao(erro.ErrorMessage);
        }

        public bool EhValido() => !this._notificacoes.Any();
        public IReadOnlyList<string> ObterNotificacoes() => this._notificacoes.ToArray();
    }
}
