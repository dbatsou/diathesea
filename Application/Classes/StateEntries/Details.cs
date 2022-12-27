using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Storage;

namespace Application.StateEntries
{
    public class Details
    {
        public class Query : IRequest<Result<StateEntry>>
        {
            public int StateEntryId { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Query, Result<StateEntry>>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<Result<StateEntry>> Handle(Query request, CancellationToken cancellationToken)
            => Result<StateEntry>.Success(await _context.StateEntry.FindAsync(request.StateEntryId));
        }
    }
}