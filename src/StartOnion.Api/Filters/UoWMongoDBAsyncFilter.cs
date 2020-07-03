using Microsoft.AspNetCore.Mvc.Filters;
using StartOnion.CrossCutting.Notifications;
using StartOnion.Repository.MongoDB.Contexts;

namespace StartOnion.Api.Filters
{
    public class UoWMongoDBAsyncFilter : IActionFilter
    {
        private readonly INotificationContext _notificator;
        private readonly ContextRepositoryMongoDBAsync _context;

        public UoWMongoDBAsyncFilter(INotificationContext notificator, ContextRepositoryMongoDBAsync context)
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
