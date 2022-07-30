using FSM.Calendar.Application.Common.Interfaces;
using FSM.Calendar.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FSM.Calendar.Application.System.Commands.CloneWeek;

public class CloneWeekCommand : IRequest
{
    public DateOnly CloneFromDate { get; set; }
    public DateOnly CloneToDate { get; set; }

    public CloneWeekCommand(DateOnly cloneFromDate, DateOnly cloneToDate)
    {
        CloneFromDate = cloneFromDate;
        CloneToDate = cloneToDate;
    }
    
    public class CloneWeekCommandHandler : IRequestHandler<CloneWeekCommand>
    {
        private readonly ICalendarDbContext _context;

        public CloneWeekCommandHandler(ICalendarDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CloneWeekCommand request, CancellationToken cancellationToken)
        {
            var slots = await _context.Slots
                                      .Where(t => t.Date >= request.CloneFromDate && t.Date < request.CloneFromDate.AddDays(7))
                                      .ToListAsync(cancellationToken);

            var weekSlots = new List<Slot>();
            
            for (var slotIndex = 0; slotIndex < slots.Count; slotIndex++)
            {
                weekSlots.Add(new Slot()
                {
                    Date = request.CloneToDate.AddDays(slotIndex),
                    FromTime = slots[slotIndex].FromTime,
                    ToTime = slots[slotIndex].ToTime,
                });
            }

            await _context.Slots.AddRangeAsync(weekSlots, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}