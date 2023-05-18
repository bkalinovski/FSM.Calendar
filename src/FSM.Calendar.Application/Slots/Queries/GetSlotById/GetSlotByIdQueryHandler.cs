using AutoMapper;
using AutoMapper.QueryableExtensions;
using FSM.Calendar.Application.Common.Interfaces;
using FSM.Calendar.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FSM.Calendar.Application.Slots.Queries.GetSlotById;

public class GetSlotByIdQueryHandler : IRequestHandler<GetSlotByIdQuery, SlotByIdVm>
{
    private readonly ICalendarDbContext _context;
    private readonly IMapper _mapper;

    public GetSlotByIdQueryHandler(ICalendarDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SlotByIdVm> Handle(GetSlotByIdQuery request, CancellationToken cancellationToken)
    {
        var slot = await _context.Slots.FindAsync(request.id);
        var territories = await _context.Territories
                                        .ProjectTo<TerritoryDto>(_mapper.ConfigurationProvider)
                                        .AsNoTracking()
                                        .ToListAsync(cancellationToken);

        var vm = new SlotByIdVm(_mapper.Map<SlotDto>(slot), territories);
                 
        return vm;
    }
}