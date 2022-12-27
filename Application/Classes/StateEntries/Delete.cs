using Application.Core;
using AutoMapper;
using MediatR;
using Storage;

namespace Application.StateEntries
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public int StateEntryId { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Command, Result<Unit>>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var stateEntry = await _context.StateEntry.FindAsync(request.StateEntryId);
                _context.Remove(stateEntry);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                    return Result<Unit>.Failure("Failed to delete the activity");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}