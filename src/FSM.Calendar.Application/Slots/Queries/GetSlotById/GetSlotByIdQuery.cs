using MediatR;

namespace FSM.Calendar.Application.Slots.Queries.GetSlotById;

public record GetSlotByIdQuery(int id) : IRequest<SlotByIdVm>;