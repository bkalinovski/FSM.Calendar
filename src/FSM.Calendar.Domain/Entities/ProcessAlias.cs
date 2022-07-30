namespace FSM.Calendar.Domain.Entities;

public class ProcessAlias
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public virtual ICollection<Process> Processes { get; private set; } = new HashSet<Process>();

    public virtual ICollection<SlotAssignment> SlotAssignments { get; private set; } = new HashSet<SlotAssignment>();
}