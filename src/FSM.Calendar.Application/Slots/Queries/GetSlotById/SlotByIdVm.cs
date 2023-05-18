using FSM.Calendar.Application.Common.Models;

namespace FSM.Calendar.Application.Slots.Queries.GetSlotById;

public class SlotByIdVm
{
    public SlotDto Slot { get; private init; }

    public IReadOnlyList<TerritoryDto> Territories { get; private init; }

    public SlotByIdVm(SlotDto slot, IReadOnlyList<TerritoryDto> territories)
    {
        Slot = slot;
        Territories = territories;
    }
}