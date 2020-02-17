using Microsoft.AspNetCore.Mvc.Filters;
using StartOnion.CrossCutting.Notifications;
using StartOnion.Repository.RavenDB.Contexts;

namespace StartOnion.Api.Filters
{
    public class UoWRavenDBFilter : IActionFilter
    {
        private readonly INotificationContext _notificator;
        private readonly ContextRepositoryRavenDB _context;

        public UoWRavenDBFilter(INotificationContext notificator, ContextRepositoryRavenDB context)
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
