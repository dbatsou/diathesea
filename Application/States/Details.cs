using Application.Core;
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
            public Handler(DataContext _context)
            : base(_context) { }

            public async Task<Domain.Entities.State> Handle(Query request, CancellationToken cancellationToken)
            => await _context.State.FindAsync(request.StateId);
        }
    }
}