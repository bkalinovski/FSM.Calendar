using MediatR;

namespace FSM.Calendar.Application.TeamAssignments.Commands.CreateTeamAssignment;

public record CreateTeamAssignmentCommand(int SlotId, int TeamId, int TerritoryId, int ProcessId) : IRequest;