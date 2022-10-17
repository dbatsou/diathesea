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
        public class Query : IRequest<List<StateEntry>> { }

        public class Handler : BaseHandler, IRequestHandler<Query, List<StateEntry>>
        {

            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<List<StateEntry>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.StateEntry.OrderByDescending(x => x.CreatedAt).ToListAsync();
            }
        }


    }
}