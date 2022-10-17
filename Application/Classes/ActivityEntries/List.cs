using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Storage;

namespace Application.ActivityEntries
{
    public class List
    {
        public class Query : IRequest<List<ActivityEntry>> { }

        public class Handler : BaseHandler, IRequestHandler<Query, List<ActivityEntry>>
        {

            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<List<ActivityEntry>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.ActivityEntry.OrderByDescending(x => x.CreatedAt).ToListAsync();
            }
        }


    }
}