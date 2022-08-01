using FluentValidation;
using FSM.Calendar.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FSM.Calendar.Application.SlotAssignments.Commands.UpdateSLotAssignment;

public class UpdateSlotAssignmentCommandValidator : AbstractValidator<UpdateSlotAssignmentCommand>
{
    private readonly ICalendarDbContext _context;

    public UpdateSlotAssignmentCommandValidator(ICalendarDbContext context)
    {
        _context = context;

        RuleFor(t => t.SlotId)
            .NotEmpty();

        RuleFor(t => t.ProcessAliasId)
            .NotEmpty();

        RuleFor(t => t.TerritoryAliasId)
            .NotEmpty();

        RuleFor(t => t)
            .MustAsync(SlotAssignmentMustExistAsync).WithMessage("Slot assignment on indicated process / territory already exists")
            .MustAsync(CanDecreaseTotalCasesAsync).WithMessage("Cannot decrease number of allowed cases, some of them are already in use");

        RuleFor(t => t.TotalCases)
            .NotEmpty()
            .GreaterThanOrEqualTo(0).WithMessage("Nr of allowed cases cannot be negative")
            .LessThanOrEqualTo(50).WithMessage("Nr of allowed cases cannot be above 50");
    }

    private async Task<bool> SlotAssignmentMustExistAsync(UpdateSlotAssignmentCommand command, CancellationToken cancellationToken)
    {
        return await _context.SlotAssignments.AsNoTracking().AnyAsync(t => 
            t.SlotId == command.SlotId &&
            t.ProcessAliasId == command.ProcessAliasId &&
            t.TerritoryAliasId == command.TerritoryAliasId, cancellationToken);
    }
    
    private async Task<bool> CanDecreaseTotalCasesAsync(UpdateSlotAssignmentCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return true;
    }
}