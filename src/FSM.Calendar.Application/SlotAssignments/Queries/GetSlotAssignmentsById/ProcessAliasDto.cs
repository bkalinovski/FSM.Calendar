using FSM.Calendar.Application.Common.Mappings;
using FSM.Calendar.Domain.Entities;

namespace FSM.Calendar.Application.SlotAssignments.Queries.GetSlotAssignmentsById;

public class ProcessAliasDto : IMapFrom<ProcessAlias>
{
    public int Id { get; set; }
    
    public string Name { get; set; }
}