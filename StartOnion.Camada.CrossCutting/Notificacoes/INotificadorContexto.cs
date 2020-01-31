using System.Collections.Generic;

namespace StartOnion.Camada.CrossCutting.Notificacoes
{
    /// <summary>
    /// Contexto do padrão de notificações (Notification Pattern)
    /// </summary>
    public interface INotificadorContexto
    {
        /// <summary>
        /// Lista de notificações
        /// </summary>
        IReadOnlyCollection<string> Notificacoes { get; }

        /// <summary>
        /// Adiciona uma mensagem no contexto de notificação
        /// </summary>
        /// <param name="mensagem">Mensagem</param>
        void Adicionar(string mensagem);
        /// <summary>
        /// Adiciona uma coleção de mensagens no contexto de notificação
        /// </summary>
        /// <param name="mensagens">Mensagens</param>
        void Adicionar(ICollection<string> mensagens);
        /// <summary>
        /// Adiciona uma coleção de mensagens no contexto de notificação
        /// </summary>
        /// <param name="mensagens">Mensagens</param>
        void Adicionar(IReadOnlyCollection<string> mensagens);
        /// <summary>
        /// Adiciona uma coleção de mensagens no contexto de notificação através de uma classe notificável
        /// </summary>
        /// <param name="modeloNotificavel">Classe que herda de Notificavel</param>
        void Adicionar(Notificavel modeloNotificavel);
        /// <summary>
        /// Adiciona uma coleção de mensagens no contexto de notificação através de várias classe notificáveis
        /// </summary>
        /// <param name="modelosNotificaveis">Classes que herdam de Notificavel</param>
        void Adicionar(params Notificavel[] modelosNotificaveis);

        /// <summary>
        /// Possui notificações no contexto?
        /// </summary>
        /// <returns></returns>
        bool PossuiNotificacoes();
    }
}
