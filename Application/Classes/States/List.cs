using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Storage;
namespace Application.States
{
    public class List
    {
        public class Query : IRequest<Result<List<State>>> { }

        public class Handler : BaseHandler, IRequestHandler<Query, Result<List<State>>>
        {

            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<Result<List<State>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<State>>.Success(await _context.State.OrderBy(x => x.StateId).ToListAsync());
            }
        }


    }
}