using FSM.Calendar.Application.Common.Exceptions;
using FSM.Calendar.Application.Common.Interfaces;
using FSM.Calendar.Domain.Entities;
using MediatR;

namespace FSM.Calendar.Application.Slots.Commands.DeleteSlot;

public class DeleteSlotCommand : IRequest
{
    public int Id { get; set; }
    
    public class DeleteSlotCommandHandler : IRequestHandler<DeleteSlotCommand>
    {
        private readonly ICalendarDbContext _context;

        public DeleteSlotCommandHandler(ICalendarDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSlotCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Slots.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Slot), request.Id);
            }

            /*var hasOrders = _context.OrderDetails.Any(od => od.ProductId == entity.ProductId);
            if (hasOrders)
            {
                throw new DeleteFailureException(nameof(Product), request.Id, "There are existing orders associated with this product.");
            }*/

            _context.Slots.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}