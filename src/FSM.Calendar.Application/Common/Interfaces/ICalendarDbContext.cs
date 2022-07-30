using FSM.Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FSM.Calendar.Application.Common.Interfaces;

public interface ICalendarDbContext
{
    DbSet<Territory> Territories { get; set; }
    
    DbSet<Slot> Slots { get; set; }
    
    DbSet<TerritoryAlias> TerritoryAliases { get; set; }
    
    DbSet<Team> Teams { get; set; }
    
    DbSet<Process> Processes { get; set; }
    
    DbSet<ProcessAlias> ProcessAliases { get; set; }
    
    DbSet<TeamAssignment> TeamAssignments { get; set; }
    
    DbSet<SlotAssignment> SlotAssignments { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}