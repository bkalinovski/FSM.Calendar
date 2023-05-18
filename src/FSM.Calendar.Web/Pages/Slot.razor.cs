using FSM.Calendar.Application.Common.Models;
using FSM.Calendar.Application.Slots.Queries.GetSlotById;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace FSM.Calendar.Web.Pages;

public partial class Slot
{
    [Inject] private IMediator Mediator { get; set; }
    
    [Parameter] public int SlotId { get; set; }

    private SlotDto SlotDetails { get; set; }
    private IReadOnlyList<TerritoryDto> Territories { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var vm = await Mediator.Send<SlotByIdVm>(new GetSlotByIdQuery(SlotId));
        SlotDetails = vm.Slot;
        Territories = vm.Territories;
        await base.OnInitializedAsync();
    }
}