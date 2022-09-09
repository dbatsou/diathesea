using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Storage;

namespace Application.States
{
    public class Edit
    {
        public class Command : IRequest<State>
        {
            public State State { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Command, State>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper)
            {
            }

            public async Task<State> Handle(Command request, CancellationToken cancellationToken)
            {
                var state = await _context.State.FindAsync(request.State.StateId);
                _mapper.Map(request.State, state);
                await _context.SaveChangesAsync();

                return state;
            }
        }
    }
}