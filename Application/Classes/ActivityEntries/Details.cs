using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Storage;

namespace Application.ActivityEntries
{
    public class Details
    {
        public class Query : IRequest<ActivityEntry>
        {
            public int ActivityEntryId { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Query, ActivityEntry>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<ActivityEntry> Handle(Query request, CancellationToken cancellationToken)
            => await _context.ActivityEntry.FindAsync(request.ActivityEntryId);
        }
    }
}