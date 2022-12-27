using Application.Core;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Storage;

namespace Application.StateEntries
{
    public class Edit
    {
        public class Command : IRequest<Result<StateEntry>>
        {
            public StateEntry StateEntry { get; set; }
            public int Id { get; set; }
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
            public Handler(DataContext context, IMapper mapper) : base(context, mapper)
            {
            }

            public async Task<Result<StateEntry>> Handle(Command request, CancellationToken cancellationToken)
            {
                var stateEntry = await _context.StateEntry.FindAsync(request.Id);

                if (stateEntry == null)
                    return null;

                _mapper.Map(request.StateEntry, stateEntry);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                    return Result<StateEntry>.Failure("Failed to update state entry");

                return Result<StateEntry>.Success(stateEntry);
            }
        }
    }
}