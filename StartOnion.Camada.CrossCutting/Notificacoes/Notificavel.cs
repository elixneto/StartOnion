using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace StartOnion.Camada.CrossCutting.Notificacoes
{
    /// <summary>
    /// Classe notificável utilizando FluentValidation
    /// </summary>
    public abstract class Notificavel
    {
        private readonly IList<string> _notificacoes = new List<string>();

        /// <summary>
        /// Adiciona uma notificação na classe
        /// </summary>
        /// <param name="notificacao"></param>
        protected void AdicionarNotificacao(string notificacao) => _notificacoes.Add(notificacao);
        /// <summary>
        /// Adiciona notificações na classe
        /// </summary>
        /// <param name="erros"></param>
        protected void AdicionarNotificacoes(IList<ValidationFailure> erros)
        {
            foreach (var erro in erros)
                this.AdicionarNotificacao(erro.ErrorMessage);
        }

        /// <summary>
        /// A classe não possui notificações?
        /// </summary>
        /// <returns></returns>
        public bool EhValido() => !_notificacoes.Any();
        /// <summary>
        /// Retorna as notificações
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<string> ObterNotificacoes() => _notificacoes.ToArray();
    }
}
