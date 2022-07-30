namespace FSM.Calendar.Domain.Entities;

public class Territory
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int RegionId { get; set; }

    public string ExternalId { get; set; }

    public virtual TerritoryAlias TerritoryAlias { get; set; }
}