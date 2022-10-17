using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Storage;

namespace Application.StateEntries
{
    public class Create
    {
        public class Command : IRequest<StateEntry>
        {
            public StateEntry StateEntry { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Command, StateEntry>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<StateEntry> Handle(Command request, CancellationToken cancellationToken)
            {
                await _context.StateEntry.AddAsync(request.StateEntry);
                await _context.SaveChangesAsync();

                return request.StateEntry;
            }
        }
    }
}