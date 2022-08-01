using FSM.Calendar.Application;
using FSM.Calendar.Application.SlotAssignments.Queries.GetSlotAssignmentsById;
using FSM.Calendar.Application.Slots.Queries.GetSlotsByInterval;
using FSM.Calendar.Application.Slots.Commands.CloneSlot;
using FSM.Calendar.Application.Slots.Commands.CloneWeek;
using FSM.Calendar.Application.System.Commands.SeedSampleData;
using FSM.Calendar.Persistance;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FSM.Calendar.Client;

public class Program
{
    public static IConfigurationRoot Configuration { get; set; }

    public static async Task Main(string[] args)
    {
        var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
        var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) || devEnvironmentVariable.ToLower() == "development";

        var configurationBuilder = new ConfigurationBuilder()
                                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                       .AddEnvironmentVariables();

        if(isDevelopment)
        {
            configurationBuilder.AddUserSecrets<Program>();
        }

        Configuration = configurationBuilder.Build();

        var serviceProvider = new ServiceCollection()
                              .AddPersistenceServices(Configuration)
                              .AddApplicationServices()
                              .BuildServiceProvider();

        var mediator = serviceProvider.GetService<IMediator>();

        await mediator!.Send(new SeedSampleDataCommand());
        
        //await mediator!.Send(new CloneSlotCommand(3, DateOnly.Parse("2022-08-01")));
            
        //var response  = await mediator!.Send(new GetSlotsByIntervalQuery(DateOnly.Parse("2022-02-22"), DateOnly.Parse("2022-02-28")));
        
        var response2  = await mediator!.Send(new GetSlotAssignmentsByIdQuery(2));
            
        Console.WriteLine("Hello World");
    }
}