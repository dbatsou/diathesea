using MediatR;
using Microsoft.EntityFrameworkCore;
using Storage;
namespace Application.States
{
    public class List
    {
        public class Query : IRequest<List<Domain.Entities.State>> { }

        public class Handler : IRequestHandler<Query, List<Domain.Entities.State>>
        {
            private readonly DataContext _context;

            public Handler(DataContext _context)
            {
                this._context = _context;
            }

            public async Task<List<Domain.Entities.State>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.State.ToListAsync();
            }
        }


    }
}