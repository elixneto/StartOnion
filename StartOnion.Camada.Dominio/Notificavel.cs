using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace StartOnion.Camada.Dominio
{
    public abstract class Notificavel
    {
        public bool EhValido => !this._notificacoes.Any();
        private readonly IList<string> _notificacoes = new List<string>();
        public IReadOnlyList<string> Notificacoes => this._notificacoes.ToArray();

        protected void AdicionarNotificacao(string notificacao) => this._notificacoes.Add(notificacao);
        protected void AdicionarNotificacoes(IList<ValidationFailure> erros)
        {
            foreach (var erro in erros)
                this.AdicionarNotificacao(erro.ErrorMessage);
        }
    }
}
