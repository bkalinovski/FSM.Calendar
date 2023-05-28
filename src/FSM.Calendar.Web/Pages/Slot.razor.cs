using FSM.Calendar.Application.Common.Models;
using FSM.Calendar.Application.Slots.Queries.GetSlotById;
using FSM.Calendar.Application.TeamAssignments.Commands.CreateTeamAssignment;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace FSM.Calendar.Web.Pages;

public partial class Slot
{
    [Inject] private IMediator Mediator { get; set; }
    
    [Parameter] public int SlotId { get; set; }

    private SlotDto SlotDetails { get; set; }
    private IReadOnlyList<TerritoryDto> Territories { get; set; }
    private IReadOnlyList<TeamDto> Teams { get; set; }
    
    private IReadOnlyList<SlotByIdVm.TeamAssignmentDto> TeamAssignments { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var vm = await Mediator.Send<SlotByIdVm>(new GetSlotByIdQuery(SlotId));
        SlotDetails = vm.Slot;
        Territories = vm.Territories;
        Teams = vm.Teams;
        TeamAssignments = vm.TeamAssignments;
        await base.OnInitializedAsync();
    }

    private async Task AssignTeam(int teamId, int territoryId)
    {
        await Mediator.Send(new CreateTeamAssignmentCommand(SlotId, teamId, territoryId, 1));
        
        var vm = await Mediator.Send<SlotByIdVm>(new GetSlotByIdQuery(SlotId));
        SlotDetails = vm.Slot;
        Territories = vm.Territories;
        Teams = vm.Teams;
        TeamAssignments = vm.TeamAssignments;
    }
}