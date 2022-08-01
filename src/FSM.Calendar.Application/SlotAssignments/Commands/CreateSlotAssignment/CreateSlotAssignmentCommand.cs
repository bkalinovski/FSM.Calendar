using FSM.Calendar.Application.Common.Interfaces;
using FSM.Calendar.Domain.Entities;
using MediatR;

namespace FSM.Calendar.Application.SlotAssignments.Commands.CreateSlotAssignment;

public record CreateSlotAssignmentCommand(int SlotId, int TerritoryAliasId, int ProcessAliasId, int TotalCases) : IRequest
{
    public class CreateSlotAssignmentCommandHandler : IRequestHandler<CreateSlotAssignmentCommand>
    {
        private readonly ICalendarDbContext _calendarDbContext;

        public CreateSlotAssignmentCommandHandler(ICalendarDbContext calendarDbContext)
        {
            _calendarDbContext = calendarDbContext;
        }

        public async Task<Unit> Handle(CreateSlotAssignmentCommand command, CancellationToken cancellationToken)
        {
            var entity = new SlotAssignment()
            {
                SlotId = command.SlotId,
                ProcessAliasId = command.ProcessAliasId,
                TerritoryAliasId = command.TerritoryAliasId,
                TotalCases = command.TotalCases
            };

            _calendarDbContext.SlotAssignments.Add(entity);

            await _calendarDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}