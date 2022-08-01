using FluentValidation;
using FSM.Calendar.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FSM.Calendar.Application.SlotAssignments.Commands.CreateSlotAssignment;

public class CreateSlotAssignmentCommandValidator : AbstractValidator<CreateSlotAssignmentCommand>
{
    private readonly ICalendarDbContext _context;

    public CreateSlotAssignmentCommandValidator(ICalendarDbContext context)
    {
        _context = context;
        
        RuleFor(t => t.SlotId)
            .NotEmpty()
            .MustAsync(SlotMustExistAsync).WithMessage("Slot with given id does not exist");

        RuleFor(t => t.ProcessAliasId)
            .NotEmpty()
            .MustAsync(ProcessAliasMustExistAsync).WithMessage("Process alias with given id does not exist");

        RuleFor(t => t.TerritoryAliasId)
            .NotEmpty()
            .MustAsync(TerritoryAliasMustExistAsync).WithMessage("Territory alias with given id does not exist");
        
        RuleFor(t => t)
            .MustAsync(SlotAssignmentMustNotExistAsync).WithMessage("Slot assignment on indicated process / territory already exists");

        RuleFor(t => t.TotalCases)
            .NotEmpty()
            .GreaterThanOrEqualTo(0).WithMessage("Nr of allowed cases cannot be negative")
            .LessThanOrEqualTo(50).WithMessage("Nr of allowed cases cannot be above 50");
    }
    
    private async Task<bool> SlotMustExistAsync(int slotId, CancellationToken cancellationToken)
    {
        return await _context.Slots.AsNoTracking().AnyAsync(t => t.Id == slotId, cancellationToken);
    }
    
    private async Task<bool> ProcessAliasMustExistAsync(int processAliasId, CancellationToken cancellationToken)
    {
        return await _context.ProcessAliases.AsNoTracking().AnyAsync(t => t.Id == processAliasId, cancellationToken);
    }
    
    private async Task<bool> TerritoryAliasMustExistAsync(int territoryAliasId, CancellationToken cancellationToken)
    {
        return await _context.TerritoryAliases.AsNoTracking().AnyAsync(t => t.Id == territoryAliasId, cancellationToken);
    }
    
    private async Task<bool> SlotAssignmentMustNotExistAsync(CreateSlotAssignmentCommand command, CancellationToken cancellationToken)
    {
        return await _context.SlotAssignments.AsNoTracking().AnyAsync(t => 
            t.SlotId == command.SlotId &&
            t.ProcessAliasId == command.ProcessAliasId &&
            t.TerritoryAliasId == command.TerritoryAliasId, cancellationToken) == false;
    }
}