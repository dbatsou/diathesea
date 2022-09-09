using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Storage;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest<Activity>
        {
            public Activity Activity { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Command, Activity>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper)
            {
            }

            public async Task<Activity> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activity.FindAsync(request.Activity.ActivityId);
                _mapper.Map(request.Activity, activity);
                await _context.SaveChangesAsync();

                return activity;
            }
        }
    }
}