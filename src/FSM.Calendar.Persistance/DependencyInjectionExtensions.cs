using FSM.Calendar.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FSM.Calendar.Persistance;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CalendarDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CalendarDatabase")));

        services.AddScoped<ICalendarDbContext>(provider => provider.GetService<CalendarDbContext>());

        return services;
    }
}