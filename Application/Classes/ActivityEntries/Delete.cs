using Application.Core;
using AutoMapper;
using MediatR;
using Storage;

namespace Application.ActivityEntries
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int ActivityEntryId { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Command>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var state = await _context.ActivityEntry.FindAsync(request.ActivityEntryId);
                _context.Remove(state);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}