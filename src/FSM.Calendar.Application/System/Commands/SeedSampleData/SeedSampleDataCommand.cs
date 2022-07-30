using FSM.Calendar.Application.Common.Interfaces;
using MediatR;

namespace FSM.Calendar.Application.System.Commands.SeedSampleData;

public class SeedSampleDataCommand : IRequest
{
    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly ICalendarDbContext _context;

        public SeedSampleDataCommandHandler(ICalendarDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(_context);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}