using FSM.Calendar.Application.Common.Interfaces;
using FSM.Calendar.Domain.Common;
using FSM.Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FSM.Calendar.Persistance;

/*
    cd FSM.Calendar.Persistance
    dotnet ef migrations add Initial -p ../FSM.Calendar.Persistance -s ../FSM.Calendar.Client
    dotnet ef database update -p ../FSM.Calendar.Persistance -s ../FSM.Calendar.Client
*/

public class CalendarDbContext : DbContext, ICalendarDbContext
{
    private readonly ICurrentUserService _currentUserService;
    
    public CalendarDbContext(DbContextOptions<CalendarDbContext> options) : base(options) { }
    
    public CalendarDbContext(DbContextOptions<CalendarDbContext> options, ICurrentUserService currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
    }

    public DbSet<Territory> Territories { get; set; }
    public DbSet<Slot> Slots { get; set; }
    public DbSet<TerritoryAlias> TerritoryAliases { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Process> Processes { get; set; }
    public DbSet<ProcessAlias> ProcessAliases { get; set; }
    public DbSet<TeamAssignment> TeamAssignments { get; set; }
    public DbSet<SlotAssignment> SlotAssignments { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.Created = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _currentUserService.UserId;
                    entry.Entity.LastModified = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CalendarDbContext).Assembly);
    }
}