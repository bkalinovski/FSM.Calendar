using AutoMapper;
using FSM.Calendar.Application.Common.Models;
using FSM.Calendar.Application.SlotAssignments.Queries.GetSlotAssignmentsById;
using FSM.Calendar.Domain.Entities;

namespace FSM.Calendar.Application.Common.Mappings;

public class CustomMappingProfile : Profile
{
    public CustomMappingProfile()
    {
        CreateMap<Slot, SlotDto>();
        
        CreateMap<ProcessAlias, ProcessAliasDto>();
        
        CreateMap<TerritoryAlias, TerritoryAliasDto>();
        
        CreateMap<Territory, TerritoryDto>();

        CreateMap<SlotAssignment, SlotAssignmentDto>()
            .ForMember(t => t.MaxCount, expression => expression.MapFrom(t => t.TotalCases));
    }
}