using AutoMapper;
using AutoMapper.QueryableExtensions;
using FSM.Calendar.Application.Common.Interfaces;
using FSM.Calendar.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FSM.Calendar.Application.Slots.Queries.GetSlotsByInterval;

public class GetSlotsByIntervalQuery : IRequest<SlotsListVm>
{
    private DateOnly FromDate { get; set; }
    private DateOnly ToDate { get; set; }

    public GetSlotsByIntervalQuery(DateOnly fromDate, DateOnly toDate)
    {
        FromDate = fromDate;
        ToDate = toDate;
    }
    
    public class GetSlotsByIntervalQueryHandler : IRequestHandler<GetSlotsByIntervalQuery, SlotsListVm>
    {
        private readonly ICalendarDbContext _context;
        private readonly IMapper _mapper;

        public GetSlotsByIntervalQueryHandler(ICalendarDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SlotsListVm> Handle(GetSlotsByIntervalQuery request, CancellationToken cancellationToken)
        {
            var slots = await _context.Slots
                                      .Where(t => t.Date >= request.FromDate && t.Date <= request.ToDate)
                                      .ProjectTo<SlotDto>(_mapper.ConfigurationProvider)
                                      .OrderBy(e => e.Date)
                                      .ThenBy(t => t.FromTime)
                                      .ThenBy(t => t.ToTime)
                                      .ToListAsync(cancellationToken);

            var vm = new SlotsListVm
            {
                Slots = slots
            };
                 
            return vm;
        }
    }
}