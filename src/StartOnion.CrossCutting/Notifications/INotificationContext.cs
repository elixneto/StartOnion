using System.Collections.Generic;

namespace StartOnion.CrossCutting.Notifications
{
    /// <summary>
    /// Notification context (Notification Pattern)
    /// </summary>
    public interface INotificationContext
    {
        /// <summary>
        /// Notifications list
        /// </summary>
        IReadOnlyCollection<string> Notifications { get; }

        /// <summary>
        /// Add a message to the context
        /// </summary>
        /// <param name="message">Message</param>
        void Add(string message);
        /// <summary>
        /// Add messages to the context
        /// </summary>
        /// <param name="messages">Messages</param>
        void Add(IEnumerable<string> messages);
        /// <summary>
        /// Add messages to the context
        /// </summary>
        /// <param name="notifiable">Notifiable class</param>
        void Add(Notifiable notifiable);
        /// <summary>
        /// Add messages to the context
        /// </summary>
        /// <param name="notifiableClasses">Notifiable classes</param>
        void Add(params Notifiable[] notifiableClasses);

        /// <summary>
        /// If has notifications
        /// </summary>
        /// <returns></returns>
        bool HasNotifications();
    }
}
