using Microsoft.AspNetCore.Mvc.Filters;
using StartOnion.CrossCutting.Notifications;
using StartOnion.Repository.LiteDB.Contexts;

namespace StartOnion.Api.Filters
{
    public class UoWLiteDBFilter : IActionFilter
    {
        private readonly INotificationContext _notificator;
        private readonly ContextRepositoryLiteDB _context;

        public UoWLiteDBFilter(INotificationContext notificator, ContextRepositoryLiteDB context)
        {
            _notificator = notificator;
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _context.OpenSession();
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
