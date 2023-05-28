using FSM.Calendar.Application.Common.Interfaces;
using FSM.Calendar.Domain.Entities;
using MediatR;

namespace FSM.Calendar.Application.TeamAssignments.Commands.CreateTeamAssignment;

public class CreateTeamAssignmentCommandHandler : IRequestHandler<CreateTeamAssignmentCommand>
{
    private readonly ICalendarDbContext _context;

    public CreateTeamAssignmentCommandHandler(ICalendarDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateTeamAssignmentCommand request, CancellationToken cancellationToken)
    {
        var entity = new TeamAssignment()
        {
            SlotId = request.SlotId,
            TeamId = request.TeamId,
            TerritoryId = request.TerritoryId,
            ProcessId = request.ProcessId
        };

        _context.TeamAssignments.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}