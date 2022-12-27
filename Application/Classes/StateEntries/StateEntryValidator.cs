using Domain.Entities;
using FluentValidation;

namespace Application.StateEntries
{
    public class StateEntryValidator : AbstractValidator<StateEntry>
    {
        public StateEntryValidator()
        {
            int year = 2022;
            RuleFor(x => x.Date.Year).GreaterThanOrEqualTo(year);
            RuleFor(x => x.StateId).NotNull().NotEmpty();
        }
    }
}