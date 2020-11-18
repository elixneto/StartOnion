using System.Collections.Generic;
using System.Linq;

namespace StartOnion.CrossCutting.Notifications
{
    /// <summary>
    /// Notification context (Notification Pattern)
    /// </summary>
    public sealed class NotificationContext : INotificationContext
    {
        private readonly List<Notification> _notifications = new List<Notification>();

        /// <summary>
        /// Notifications list
        /// </summary>
        public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();

        public void Add(int code) => _notifications.Add(new Notification(code));
        /// <summary>
        /// Add a message to the context
        /// </summary>
        /// <param name="message">Message</param>
        public void Add(string message) => _notifications.Add(new Notification(message));
        /// <summary>
        /// Add a message to the context
        /// </summary>
        /// <param name="code">Message</param>
        /// <param name="message">Message</param>
        public void Add(int code, string message) => _notifications.Add(new Notification(code, message));
        /// <summary>
        /// Add a Notificatio nobject to the context
        /// </summary>
        /// <param name="notification">Notification object</param>
        public void Add(Notification notification) => _notifications.Add(notification);
        /// <summary>
        /// Add messages to the context
        /// </summary>
        /// <param name="messages">Messages</param>
        public void Add(IEnumerable<string> messages)
        {
            foreach (var message in messages)
                this.Add(message);
        }
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
                    _notifications.AddRange(notifications);
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
        public bool HasNotifications() => _notifications.Any();
    }
}
