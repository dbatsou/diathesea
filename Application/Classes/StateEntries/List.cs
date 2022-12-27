using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Storage;

namespace Application.StateEntries
{
    public class List
    {
        public class Query : IRequest<Result<List<StateEntry>>> { }

        public class Handler : BaseHandler, IRequestHandler<Query, Result<List<StateEntry>>>
        {

            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<Result<List<StateEntry>>> Handle(Query request, CancellationToken cancellationToken)
            => Result<List<StateEntry>>.Success(await _context.StateEntry.OrderByDescending(x => x.Date).ToListAsync());
        }
    }
}