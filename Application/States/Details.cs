using Application.Core;
using AutoMapper;
using MediatR;
using Storage;

namespace Application.States
{
    public class Details
    {
        public class Query : IRequest<Domain.Entities.State>
        {
            public int StateId { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Query, Domain.Entities.State>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<Domain.Entities.State> Handle(Query request, CancellationToken cancellationToken)
            => await _context.State.FindAsync(request.StateId);
        }
    }
}