using System.Collections.Generic;
using System.Linq;

namespace StartOnion.CrossCutting.Notifications
{
    /// <summary>
    /// Notification context (Notification Pattern)
    /// </summary>
    public sealed class NotificationContext : INotificationContext
    {
        private readonly List<string> _notificacoes = new List<string>();

        /// <summary>
        /// Notifications list
        /// </summary>
        public IReadOnlyCollection<string> Notifications => _notificacoes;

        /// <summary>
        /// Add a message to the context
        /// </summary>
        /// <param name="message">Message</param>
        public void Add(string message) => _notificacoes.Add(message);
        /// <summary>
        /// Add messages to the context
        /// </summary>
        /// <param name="messages">Messages</param>
        public void Add(IEnumerable<string> messages) => _notificacoes.AddRange(messages);
        /// <summary>
        /// Add messages to the context
        /// </summary>
        /// <param name="notifiable">Notifiable class</param>
        public void Add(Notifiable notifiable)
        {
            if (notifiable != default)
            {
                var notifications = notifiable.GetNotifications();
                if(notifications != default)
                    _notificacoes.AddRange(notifications);
            }
        }
        /// <summary>
        /// Add messages to the context
        /// </summary>
        /// <param name="notifiables">Notifiable classes</param>
        public void Add(params Notifiable[] notifiables)
        {
            foreach (var notifiable in notifiables)
                Add(notifiable);
        }

        /// <summary>
        /// If has notifications
        /// </summary>
        /// <returns></returns>
        public bool HasNotifications() => _notificacoes.Any();
    }
}
