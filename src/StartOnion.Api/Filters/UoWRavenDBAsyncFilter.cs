using Microsoft.AspNetCore.Mvc.Filters;
using StartOnion.CrossCutting.Notifications;
using StartOnion.Repository.RavenDB.Contexts;

namespace StartOnion.Api.Filters
{
    public class UoWRavenDBAsyncFilter : IActionFilter
    {
        private readonly INotificationContext _notificator;
        private readonly ContextRepositoryRavenDBAsync _context;

        public UoWRavenDBAsyncFilter(INotificationContext notificator, ContextRepositoryRavenDBAsync context)
        {
            _notificator = notificator;
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!_notificator.HasNotifications())
                _context.Commit();
            else
                _context.Rollback();
        }
    }
}
