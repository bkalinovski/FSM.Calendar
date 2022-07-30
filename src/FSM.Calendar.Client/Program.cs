using FSM.Calendar.Application;
using FSM.Calendar.Application.Slots.Queries.GetSlotsByInterval;
using FSM.Calendar.Application.System.Commands.CloneSlot;
using FSM.Calendar.Application.System.Commands.CloneWeek;
using FSM.Calendar.Application.System.Commands.SeedSampleData;
using FSM.Calendar.Persistance;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FSM.Calendar.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
                                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                       .AddEnvironmentVariables()
                                       .AddCommandLine(args)
                                       .Build();

        var serviceProvider = new ServiceCollection()
                              .AddPersistenceServices(configuration)
                              .AddApplicationServices()
                              .BuildServiceProvider();

        var mediator = serviceProvider.GetService<IMediator>();

        await mediator!.Send(new SeedSampleDataCommand());
        
        await mediator!.Send(new CloneSlotCommand(4, DateOnly.Parse("2022-07-29")));
            
        var response  = await mediator!.Send(new GetSlotsByIntervalQuery(DateOnly.Parse("2022-02-22"), DateOnly.Parse("2022-02-28")));
        
        var response2  = await mediator!.Send(new GetSlotsByIntervalQuery(DateOnly.Parse("2022-03-01"), DateOnly.Parse("2022-03-28")));
            
        Console.WriteLine("Hello World");
    }
}