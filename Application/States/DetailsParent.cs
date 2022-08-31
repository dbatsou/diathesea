using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Storage;

namespace Application.States
{
    public class DetailsParent
    {
        public class Query : IRequest<List<Domain.Entities.State>>
        {
            public int ParentStateID { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Query, List<Domain.Entities.State>>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<List<Domain.Entities.State>> Handle(Query request, CancellationToken cancellationToken)
            => await _context.State.Where(st => st.ParentStateID == request.ParentStateID).ToListAsync();
        }
    }
}