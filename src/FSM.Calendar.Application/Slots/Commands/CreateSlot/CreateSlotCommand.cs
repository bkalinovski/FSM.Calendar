using FSM.Calendar.Application.Common.Interfaces;
using FSM.Calendar.Domain.Entities;
using MediatR;

namespace FSM.Calendar.Application.Slots.Commands.CreateSlot;

public class CreateSlotCommand : IRequest<int>
{
    public DateOnly Date { get; set; }

    public TimeOnly FromTime { get; set; }

    public TimeOnly ToTime { get; set; }

    public class CreateSlotCommandHandler : IRequestHandler<CreateSlotCommand, int>
    {
        private readonly ICalendarDbContext _calendarDbContext;

        public CreateSlotCommandHandler(ICalendarDbContext calendarDbContext)
        {
            _calendarDbContext = calendarDbContext;
        }

        public async Task<int> Handle(CreateSlotCommand command, CancellationToken cancellationToken)
        {
            var entity = new Slot()
            {
                Date = command.Date,
                FromTime = command.FromTime,
                ToTime = command.ToTime
            };

            _calendarDbContext.Slots.Add(entity);

            await _calendarDbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}