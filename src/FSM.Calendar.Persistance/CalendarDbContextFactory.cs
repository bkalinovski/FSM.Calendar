using Microsoft.EntityFrameworkCore;

namespace FSM.Calendar.Persistance;

public class CalendarDbContextFactory : DesignTimeDbContextFactoryBase<CalendarDbContext>
{
    protected override CalendarDbContext CreateNewInstance(DbContextOptions<CalendarDbContext> options)
    {
        return new CalendarDbContext(options);
    }
}