using FSM.Calendar.Application.Common.Models;

namespace FSM.Calendar.Application.SlotAssignments.Queries.GetSlotAssignmentsById;

public class SlotsProcessesVm
{
    public SlotDto Slot { get; set; }

    public List<TerritoryAliasDto> TerritoryAliases { get; set; }
    
    public List<ProcessAliasDto> ProcessAliases { get; set; }

    public List<SlotAssignmentDto> SlotAssignments { get; set; }
}