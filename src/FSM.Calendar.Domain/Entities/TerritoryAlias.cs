namespace FSM.Calendar.Domain.Entities;

public class TerritoryAlias
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Territory> Territories { get; private set; } = new HashSet<Territory>();
    
    public virtual ICollection<SlotAssignment> SlotAssignments { get; private set; } = new HashSet<SlotAssignment>();
}