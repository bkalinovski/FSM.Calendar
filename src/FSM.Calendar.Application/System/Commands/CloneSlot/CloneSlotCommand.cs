using FSM.Calendar.Application.Common.Exceptions;
using FSM.Calendar.Application.Common.Interfaces;
using FSM.Calendar.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FSM.Calendar.Application.System.Commands.CloneSlot;

public class CloneSlotCommand : IRequest
{
    public int Id { get; set; }
    public DateOnly CloneToDate { get; set; }

    public CloneSlotCommand(int id, DateOnly cloneToDate)
    {
        Id = id;
        CloneToDate = cloneToDate;
    }
    
    public class CloneSlotCommandHandler : IRequestHandler<CloneSlotCommand>
    {
        private readonly ICalendarDbContext _context;

        public CloneSlotCommandHandler(ICalendarDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CloneSlotCommand request, CancellationToken cancellationToken)
        {
            var slot = await _context.Slots
                                     .Include(t => t.SlotAssignments)
                                     .Include(t => t.TeamAssignments)
                                     .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (slot == null)
            {
                throw new NotFoundException(typeof(Slot).ToString(), request.Id);
            }

            var clonedSlot = new Slot()
            {
                Date = request.CloneToDate,
                FromTime = slot.FromTime,
                ToTime = slot.ToTime
            };

            await _context.Slots.AddAsync(clonedSlot, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}