using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Storage;
namespace Application.States
{
    public class List
    {
        public class Query : IRequest<List<Domain.Entities.State>> { }

        public class Handler : BaseHandler, IRequestHandler<Query, List<Domain.Entities.State>>
        {

            public Handler(DataContext _context)
            : base(_context) { }

            public async Task<List<Domain.Entities.State>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.State.ToListAsync();
            }
        }


    }
}