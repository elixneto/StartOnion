using System.Collections.Generic;
using System.Linq;

namespace StartOnion.Camada.CrossCutting.Notificacoes
{
    /// <summary>
    /// Contexto do padrão de notificações (Notification Pattern)
    /// </summary>
    public sealed class NotificadorContexto : INotificadorContexto
    {
        private readonly List<string> _notificacoes = new List<string>();

        /// <summary>
        /// Lista de notificações
        /// </summary>
        public IReadOnlyCollection<string> Notificacoes => _notificacoes;

        /// <summary>
        /// Adiciona uma mensagem no contexto de notificação
        /// </summary>
        /// <param name="mensagem">Mensagem</param>
        public void Adicionar(string mensagem) => _notificacoes.Add(mensagem);
        /// <summary>
        /// Adiciona uma coleção de mensagens no contexto de notificação
        /// </summary>
        /// <param name="mensagens">Mensagens</param>
        public void Adicionar(IEnumerable<string> mensagens) => _notificacoes.AddRange(mensagens);
        /// <summary>
        /// Adiciona uma coleção de mensagens no contexto de notificação através de uma classe notificável
        /// </summary>
        /// <param name="notificavel">Classe que herda de Notificavel</param>
        public void Adicionar(Notificavel notificavel)
        {
            if (notificavel != default)
                _notificacoes.AddRange(notificavel.ObterNotificacoes());
        }
        /// <summary>
        /// Adiciona uma coleção de mensagens no contexto de notificação através de várias classe notificáveis
        /// </summary>
        /// <param name="notificaveis">Classes que herdam de Notificavel</param>
        public void Adicionar(params Notificavel[] notificaveis)
        {
            foreach (var notificavel in notificaveis)
                Adicionar(notificavel);
        }

        /// <summary>
        /// Possui notificações no contexto?
        /// </summary>
        /// <returns></returns>
        public bool PossuiNotificacoes() => _notificacoes.Any();
    }
}
