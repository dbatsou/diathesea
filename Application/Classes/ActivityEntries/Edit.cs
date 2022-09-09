using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Storage;

namespace Application.ActivityEntries
{
    public class Edit
    {
        public class Command : IRequest<ActivityEntry>
        {
            public ActivityEntry ActivityEntry { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Command, ActivityEntry>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper)
            {
            }

            public async Task<ActivityEntry> Handle(Command request, CancellationToken cancellationToken)
            {
                var activityEntry = await _context.ActivityEntry.FindAsync(request.ActivityEntry.ActivityEntryId);
                _mapper.Map(request.ActivityEntry, activityEntry);
                await _context.SaveChangesAsync();

                return activityEntry;
            }
        }
    }
}