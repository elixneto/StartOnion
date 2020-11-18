using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace StartOnion.CrossCutting.Notifications
{
    /// <summary>
    /// Notifiable class using FluentValidation
    /// </summary>
    public abstract class Notifiable
    {
        private readonly IList<Notification> _notifications = new List<Notification>();

        protected void AddNotification(int code) => _notifications.Add(new Notification(code));
        /// <summary>
        /// Add a notification to the class
        /// </summary>
        /// <param name="message"></param>
        protected void AddNotification(string message) => _notifications.Add(new Notification(message));
        /// <summary>
        /// Add a notification to the class
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        protected void AddNotification(int code, string message) => _notifications.Add(new Notification(code, message));
        /// <summary>
        /// Add notifications to the class
        /// </summary>
        /// <param name="errors"></param>
        protected void AddNotifications(IList<ValidationFailure> errors)
        {
            foreach (var er in errors)
                this.AddNotification(er.ErrorMessage);
        }
        /// <summary>
        /// Add notifications to the class
        /// </summary>
        /// <param name="errors"></param>
        protected void AddNotifications(IList<string> errors)
        {
            foreach (var er in errors)
                this.AddNotification(er);
        }

        /// <summary>
        /// If has notifications
        /// </summary>
        /// <returns></returns>
        public bool HasNotifications() => _notifications.Any();
        /// <summary>
        /// Get the notifications
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Notification> GetNotifications() => _notifications?.ToArray();
    }
}
