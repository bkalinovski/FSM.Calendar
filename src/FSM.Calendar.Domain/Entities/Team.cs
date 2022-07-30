using FSM.Calendar.Domain.Enums;

namespace FSM.Calendar.Domain.Entities;

public class Team
{
    public int Id { get; init; }

    public string Name { get; set; }

    public Status Status { get; set; }

    public virtual ICollection<TeamAssignment> TeamAssignments { get; private set; } = new HashSet<TeamAssignment>();
}