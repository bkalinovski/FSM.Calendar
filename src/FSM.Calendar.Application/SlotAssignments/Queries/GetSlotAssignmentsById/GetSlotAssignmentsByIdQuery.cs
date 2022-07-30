using AutoMapper;
using AutoMapper.QueryableExtensions;
using FSM.Calendar.Application.Common.Exceptions;
using FSM.Calendar.Application.Common.Interfaces;
using FSM.Calendar.Application.Common.Models;
using FSM.Calendar.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FSM.Calendar.Application.SlotAssignments.Queries.GetSlotAssignmentsById;

public class GetSlotAssignmentsByIdQuery : IRequest<SlotsProcessesVm>
{
    public GetSlotAssignmentsByIdQuery(int id)
    {
        Id = id;
    }

    private int Id { get; }

    public class GetSlotAssignmentsByIdQueryHandler : IRequestHandler<GetSlotAssignmentsByIdQuery, SlotsProcessesVm>
    {
        private readonly ICalendarDbContext _context;
        private readonly IMapper _mapper;

        public GetSlotAssignmentsByIdQueryHandler(ICalendarDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SlotsProcessesVm> Handle(GetSlotAssignmentsByIdQuery request, CancellationToken cancellationToken)
        {
            var slot = await _context.Slots
                                     .ProjectTo<SlotDto>(_mapper.ConfigurationProvider)
                                     .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (slot == null)
            {
                throw new NotFoundException(nameof(Slot), request.Id);
            }
            
            var processAliases = await _context.ProcessAliases
                                              .ProjectTo<ProcessAliasDto>(_mapper.ConfigurationProvider)
                                              .OrderBy(e => e.Name)
                                              .ToListAsync(cancellationToken);
            
            var territoryAliases = await _context.TerritoryAliases
                                                .ProjectTo<TerritoryAliasDto>(_mapper.ConfigurationProvider)
                                                .OrderBy(e => e.Name)
                                                .ToListAsync(cancellationToken);
            
            var slotAssignments = await  _context.SlotAssignments
                                                 .Where(t => t.SlotId == request.Id)
                                                 .ProjectTo<SlotAssignmentDto>(_mapper.ConfigurationProvider)
                                                 .ToListAsync(cancellationToken);

            var vm = new SlotsProcessesVm
            {
                Slot = slot,
                ProcessAliases = processAliases,
                TerritoryAliases = territoryAliases,
                SlotAssignments = slotAssignments
            };
                 
            return vm;
        }
    }
}