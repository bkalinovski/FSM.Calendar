using FSM.Calendar.Application.Common.Models;

namespace FSM.Calendar.Application.Slots.Queries.GetSlotById;

public class SlotByIdVm
{
    public SlotDto Slot { get; private init; }

    public IReadOnlyList<TerritoryDto> Territories { get; private init; }
    
    public IReadOnlyList<TeamDto> Teams { get; private init; }

    public IReadOnlyList<TeamAssignmentDto> TeamAssignments { get; private init; }

    public SlotByIdVm(SlotDto slot, IReadOnlyList<TerritoryDto> territories, IReadOnlyList<TeamDto> teams, IReadOnlyList<TeamAssignmentDto> teamAssignments)
    {
        Slot = slot;
        Territories = territories;
        Teams = teams;
        TeamAssignments = teamAssignments;
    }

    public class TeamAssignmentDto
    {
        public int TeamId { get; set; }

        public int TerritoryId { get; set; }
    }
}