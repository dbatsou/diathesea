using Application.Core;
using AutoMapper;
using MediatR;
using Storage;

namespace Application.States
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Command>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var state = await _context.State.FindAsync(request.Id);
                _context.Remove(state);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}