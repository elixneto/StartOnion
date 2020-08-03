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
        private readonly IList<string> _notifications = new List<string>();

        /// <summary>
        /// Add a notification to the class
        /// </summary>
        /// <param name="message"></param>
        protected void AddNotification(string message) => _notifications.Add(message);
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
        public IReadOnlyList<string> GetNotifications() => _notifications.ToArray();
    }
}
