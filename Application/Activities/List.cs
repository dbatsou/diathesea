using Application.Core;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Storage;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : BaseHandler, IRequestHandler<Query, List<Activity>>
        {

            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activity.ToListAsync();
            }
        }


    }
}