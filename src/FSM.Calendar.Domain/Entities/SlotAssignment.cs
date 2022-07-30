namespace FSM.Calendar.Domain.Entities;

public class SlotAssignment
{
    public int SlotId { get; set; }

    public int ProcessAliasId { get; set; }

    public int TerritoryAliasId { get; set; }

    public int TotalCases { get; set; }

    public virtual Slot Slot { get; set; }

    public virtual ProcessAlias ProcessAlias { get; set; }

    public virtual TerritoryAlias TerritoryAlias { get; set; }
}