using FSM.Calendar.Application.Common.Models;

namespace FSM.Calendar.Application.Slots.Queries.GetSlotsByInterval;

public class SlotsListVm
{
    public IList<SlotDto> Slots { get; set; }
}