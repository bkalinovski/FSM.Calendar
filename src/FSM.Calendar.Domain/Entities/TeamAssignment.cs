namespace FSM.Calendar.Domain.Entities;

public class TeamAssignment
{
    public int SlotId { get; set; }

    public int TeamId { get; set; }

    public int ProcessId { get; set; }

    public int TerritoryId { get; set; }

    public virtual Slot Slot { get; set; }
    
    public virtual Team Team { get; set; }
    
    public virtual Process Process { get; set; }
    
    public virtual Territory Territory { get; set; }
}