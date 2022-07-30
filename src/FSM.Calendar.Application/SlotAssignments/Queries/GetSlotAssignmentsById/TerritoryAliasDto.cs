using FSM.Calendar.Application.Common.Mappings;
using FSM.Calendar.Domain.Entities;

namespace FSM.Calendar.Application.SlotAssignments.Queries.GetSlotAssignmentsById;

public class TerritoryAliasDto : IMapFrom<TerritoryAlias>
{
    public int Id { get; set; }

    public string Name { get; set; } 
}