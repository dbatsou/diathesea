using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Storage;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public int ActivityId { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Query, Activity>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            => await _context.Activity.FindAsync(request.ActivityId);
        }
    }
}