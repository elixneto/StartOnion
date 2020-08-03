using MediatR;

namespace StartOnion.Application.AppServices
{
    public abstract class AppService
    {
        protected readonly IMediator _mediator;

        public AppService(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
