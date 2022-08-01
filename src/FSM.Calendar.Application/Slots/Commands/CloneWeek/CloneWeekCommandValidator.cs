using FluentValidation;
using FSM.Calendar.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FSM.Calendar.Application.Slots.Commands.CloneWeek;

public class CloneWeekCommandValidator : AbstractValidator<CloneWeekCommand>
{
    private readonly ICalendarDbContext _context;

    public CloneWeekCommandValidator(ICalendarDbContext context)
    {
        _context = context;
        
        RuleFor(t => t.CloneFromDate)
            .NotEmpty()
            .LessThan(t => t.CloneToDate).WithMessage("From date cannot be greater than to date");

        RuleFor(t => t.CloneToDate)
            .NotEmpty()
            .GreaterThan(t => t.CloneFromDate).WithMessage("To date cannot be lesser than from date")
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("Cloning date cannot be lesser than today")
            .MustAsync(NoSlotsInBetween).WithMessage("There are slots in the period you selected. Cannot override them");
    }

    private async Task<bool> NoSlotsInBetween(DateOnly cloneToDate, CancellationToken cancellationToken)
    {
        return await _context.Slots
                             .Where(t => t.Date >= cloneToDate && t.Date <= cloneToDate.AddDays(7))
                             .AnyAsync(cancellationToken) == false;
    }
}