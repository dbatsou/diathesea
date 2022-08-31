using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Storage;

namespace Application.States
{
    public class Create
    {
        public class Command : IRequest<Domain.Entities.State>
        {
            public State State { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Command, Domain.Entities.State>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<Domain.Entities.State> Handle(Command request, CancellationToken cancellationToken)
            {
                await _context.State.AddAsync(request.State);
                await _context.SaveChangesAsync();

                return request.State;
            }
        }
    }
}