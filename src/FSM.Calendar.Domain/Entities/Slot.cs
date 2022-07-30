using System.ComponentModel.DataAnnotations.Schema;

namespace FSM.Calendar.Domain.Entities;

public class Slot
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly FromTime { get; set; }

    public TimeOnly ToTime { get; set; }

    [NotMapped]
    public string Description => $"{Date.ToString("dd MMMM yyyy")} | {FromTime.ToString("HH")}-{ToTime.ToString("HH")}";

    public virtual ICollection<TeamAssignment> TeamAssignments { get; set; } = new HashSet<TeamAssignment>();
    
    public virtual ICollection<SlotAssignment> SlotAssignments { get; set; } = new HashSet<SlotAssignment>();
}