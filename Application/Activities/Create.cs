using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Storage;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest<Activity>
        {
            public Activity Activity { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Command, Activity>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<Activity> Handle(Command request, CancellationToken cancellationToken)
            {
                await _context.Activity.AddAsync(request.Activity);
                await _context.SaveChangesAsync();

                return request.Activity;
            }
        }
    }
}