using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Storage;

namespace Application.States
{
    public class Details
    {
        public class Query : IRequest<Result<State>>
        {
            public int StateId { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Query, Result<State>>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<Result<State>> Handle(Query request, CancellationToken cancellationToken)
            => Result<State>.Success(await _context.State.FindAsync(request.StateId));
        }
    }
}