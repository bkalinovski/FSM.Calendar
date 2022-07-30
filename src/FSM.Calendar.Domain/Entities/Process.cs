namespace FSM.Calendar.Domain.Entities;

public class Process
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Guid ExternalId { get; set; }
    
    public int ProcessAliasId { get; set; }

    public virtual ProcessAlias ProcessAlias { get; set; }

    public virtual ICollection<TeamAssignment> TeamAssignments { get; private set; } = new HashSet<TeamAssignment>();
}