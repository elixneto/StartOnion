using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using StartOnion.CrossCutting.Notifications;
using System.Net;

namespace StartOnion.Api.Filters
{
    public class NotificationFilter : IActionFilter
    {
        private readonly INotificationContext _notificator;

        public NotificationFilter(INotificationContext notificator)
        {
            _notificator = notificator;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (_notificator.HasNotifications())
            {
                var response = JsonConvert.SerializeObject(_notificator.Notifications);

                context.Result = new ObjectResult(response)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }
    }
}
