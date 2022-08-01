using FSM.Calendar.Application.Common.Exceptions;
using FSM.Calendar.Application.Common.Interfaces;
using FSM.Calendar.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FSM.Calendar.Application.SlotAssignments.Commands.UpdateSlotAssignment;

public record UpdateSlotAssignmentCommand(int SlotId, int ProcessAliasId, int TerritoryAliasId, int TotalCases) : IRequest
{
    public class UpdateSlotAssignmentCommandHandler : IRequestHandler<UpdateSlotAssignmentCommand>
    {
        private readonly ICalendarDbContext _calendarDbContext;

        public UpdateSlotAssignmentCommandHandler(ICalendarDbContext calendarDbContext)
        {
            _calendarDbContext = calendarDbContext;
        }

        public async Task<Unit> Handle(UpdateSlotAssignmentCommand command, CancellationToken cancellationToken)
        {
            var slotAssignment = await _calendarDbContext.SlotAssignments
                                                   .AsNoTracking()
                                                   .FirstOrDefaultAsync(t => 
                                                           t.SlotId == command.SlotId &&
                                                           t.ProcessAliasId == command.ProcessAliasId &&
                                                           t.TerritoryAliasId == command.TerritoryAliasId, cancellationToken);
            
            if (slotAssignment == null)
            {
                throw new NotFoundException(nameof(SlotAssignment), new { command.SlotId, command.ProcessAliasId, command.TerritoryAliasId });
            }

            slotAssignment.TotalCases = command.TotalCases;

            await _calendarDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}