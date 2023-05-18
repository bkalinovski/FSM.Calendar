namespace FSM.Calendar.Domain.Entities;

public class AssignedCase
{
    public int Id { get; set; }

    public int SlotId { get; set; }

    public int ProcessId { get; set; }

    public int TerritoryId { get; set; }

    public Guid ExternalId { get; set; }

    public bool IsActive { get; set; }

    public virtual Slot Slot { get; set; }

    public virtual Process Process { get; set; }

    public virtual Territory Territory { get; set; }
}