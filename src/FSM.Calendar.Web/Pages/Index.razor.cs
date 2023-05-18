using FSM.Calendar.Application.Slots.Queries.GetSlotsByInterval;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace FSM.Calendar.Web.Pages;

public partial class Index
{
    [Inject] private IMediator Mediator { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
        
    private SlotsListVm? SlotList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }

    private async Task RetrieveSlotsByPeriodAsync(DateOnly fromDate, DateOnly toDate)
    {
        SlotList = await Mediator.Send(new GetSlotsByIntervalQuery(fromDate, toDate));
    }

    private void OpenSlot(int slotId)
    {
        NavigationManager.NavigateTo($"/slots/{slotId}");
    }
}