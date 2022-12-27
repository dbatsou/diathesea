using Application.Core;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Storage;

namespace Application.StateEntries
{
    public class Create
    {
        public class Command : IRequest<Result<StateEntry>>
        {
            public StateEntry StateEntry { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.StateEntry).SetValidator(new StateEntryValidator());
            }
        }

        public class Handler : BaseHandler, IRequestHandler<Command, Result<StateEntry>>
        {
            public Handler(DataContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<Result<StateEntry>> Handle(Command request, CancellationToken cancellationToken)
            {
                await _context.StateEntry.AddAsync(request.StateEntry);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                    return Result<StateEntry>.Failure("Failed to create activity");

                return Result<StateEntry>.Success(request.StateEntry);
            }
        }
    }
}