using FSM.Calendar.Application.Common.Mappings;
using FSM.Calendar.Domain.Entities;

namespace FSM.Calendar.Application.SlotAssignments.Queries.GetSlotAssignmentsById;

public class SlotAssignmentDto : IMapFrom<SlotAssignment>
{
    public int TerritoryAliasId { get; set; }

    public int ProcessAliasId { get; set; }

    public int MaxCount { get; set; }

    public int UsedCount { get; set; }
}