using FSM.Calendar.Application.Common.Mappings;
using FSM.Calendar.Domain.Entities;

namespace FSM.Calendar.Application.Common.Models;

public class SlotDto : IMapFrom<Slot>
{
    public int Id { get; set; }
    
    public DateOnly Date { get; set; }

    public TimeOnly FromTime { get; set; }

    public TimeOnly ToTime { get; set; }

    public string Description { get; set; }
}