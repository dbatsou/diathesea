using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Storage;

namespace Application.States
{
    public class DetailsParent
    {
        public class Query : IRequest<Result<List<State>>>
        {
            public int ParentStateID { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Query, Result<List<State>>>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<Result<List<State>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.State.Where(st => st.ParentStateID == request.ParentStateID).ToListAsync();
                return Result<List<State>>.Success(result);

            }
        }
    }
}