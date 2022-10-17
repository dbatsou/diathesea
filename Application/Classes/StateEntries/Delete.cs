using Application.Core;
using AutoMapper;
using MediatR;
using Storage;

namespace Application.StateEntries
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int StateEntryId { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Command>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var stateEntry = await _context.StateEntry.FindAsync(request.StateEntryId);
                _context.Remove(stateEntry);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}