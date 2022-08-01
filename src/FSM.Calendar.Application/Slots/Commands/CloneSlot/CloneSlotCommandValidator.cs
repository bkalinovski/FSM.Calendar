using FluentValidation;
using FSM.Calendar.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FSM.Calendar.Application.Slots.Commands.CloneSlot;

public class CloneSlotCommandValidator : AbstractValidator<CloneSlotCommand>
{
    private readonly ICalendarDbContext _context;

    public CloneSlotCommandValidator(ICalendarDbContext context)
    {
        _context = context;

        RuleFor(t => t.Id)
            .NotEmpty();

        RuleFor(t => t.CloneToDate)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("Cloning date cannot be lesser than today")
            .MustAsync(NotBeOccupied).WithMessage("Clone to date already in use");
    }

    private async Task<bool> NotBeOccupied(DateOnly cloneToDate, CancellationToken cancellationToken)
    {
        return await _context.Slots
                             .Where(t => t.Date == cloneToDate)
                             .AnyAsync(cancellationToken) == false;
    }
}