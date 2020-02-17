using AutoMapper;
using MediatR;

namespace StartOnion.Application.AppServices
{
    public abstract class AppService
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public AppService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    }
}
