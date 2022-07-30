using FSM.Calendar.Application.Common.Interfaces;
using FSM.Calendar.Domain.Entities;
using FSM.Calendar.Domain.Enums;

namespace FSM.Calendar.Application.System.Commands.SeedSampleData;

public class SampleDataSeeder
{
    private readonly ICalendarDbContext _context;

    public SampleDataSeeder(ICalendarDbContext context)
    {
        _context = context;
    }
    
    public async Task SeedAllAsync(CancellationToken cancellationToken)
    {
        if (_context.Slots.Any())
        {
            return;
        }

        await SeedSlotsAsync(cancellationToken);

        await SeedRegionsAsync(cancellationToken);

        await SeedTerritoriesAsync(cancellationToken);

        await SeedProcessAliasesAsync(cancellationToken);

        await SeedProcessesAsync(cancellationToken);

        await SeedTeamsAsync(cancellationToken);

        await SeedTeamAssignmentsAsync(cancellationToken);

        await SeedSlotAssignmentsAsync(cancellationToken);
    }
    
    private async Task SeedSlotAssignmentsAsync(CancellationToken cancellationToken)
    {
        var slotAssignments = new[]
        {
            new SlotAssignment { SlotId = 1, TerritoryAliasId = 1, ProcessAliasId = 1, TotalCases = 10 },
            new SlotAssignment { SlotId = 1, TerritoryAliasId = 5, ProcessAliasId = 1, TotalCases = 20 },
            new SlotAssignment { SlotId = 2, TerritoryAliasId = 7, ProcessAliasId = 1, TotalCases = 10 },
            new SlotAssignment { SlotId = 2, TerritoryAliasId = 10, ProcessAliasId = 2, TotalCases = 15 },
            new SlotAssignment { SlotId = 2, TerritoryAliasId = 12, ProcessAliasId = 2, TotalCases = 5 }
        };

        _context.SlotAssignments.AddRange(slotAssignments);

        await _context.SaveChangesAsync(cancellationToken);
    }
    
    private async Task SeedTeamAssignmentsAsync(CancellationToken cancellationToken)
    {
        var teamAssignments = new[]
        {
            new TeamAssignment { ProcessId = 1, SlotId = 1, TeamId = 1, TerritoryId = 2 },
            new TeamAssignment { ProcessId = 2, SlotId = 2, TeamId = 2, TerritoryId = 3 },
            new TeamAssignment { ProcessId = 3, SlotId = 1, TeamId = 3, TerritoryId = 4 },
            new TeamAssignment { ProcessId = 1, SlotId = 2, TeamId = 4, TerritoryId = 5 }
        };

        _context.TeamAssignments.AddRange(teamAssignments);

        await _context.SaveChangesAsync(cancellationToken);
    }
    
    private async Task SeedSlotsAsync(CancellationToken cancellationToken)
    {
        var slots = new[]
        {
            new Slot { Date = DateOnly.Parse("2022-01-01"), FromTime = TimeOnly.Parse("08:00:00.0000000"), ToTime = TimeOnly.Parse("14:00:00.0000000") },
            new Slot { Date = DateOnly.Parse("2022-02-22"), FromTime = TimeOnly.Parse("08:00:00.0000000"), ToTime = TimeOnly.Parse("14:00:00.0000000") },
            new Slot { Date = DateOnly.Parse("2022-02-23"), FromTime = TimeOnly.Parse("08:00:00.0000000"), ToTime = TimeOnly.Parse("14:00:00.0000000") }
        };

        _context.Slots.AddRange(slots);

        await _context.SaveChangesAsync(cancellationToken);
    }
    
    private async Task SeedTeamsAsync(CancellationToken cancellationToken)
    {
        var teams = new[]
        {
            new Team { Name = "ECR01", Status = Status.Enabled },
            new Team { Name = "ECR02", Status = Status.Enabled },
            new Team { Name = "ECR03", Status = Status.Enabled },
            new Team { Name = "ECR04", Status = Status.Enabled },
            new Team { Name = "ECR05", Status = Status.Enabled },
            new Team { Name = "ECR06", Status = Status.Enabled },
            new Team { Name = "ECR07", Status = Status.Enabled },
            new Team { Name = "ECR08", Status = Status.Enabled },
            new Team { Name = "ECR09", Status = Status.Enabled },
            new Team { Name = "ECR10", Status = Status.Enabled },
            new Team { Name = "ECR11", Status = Status.Enabled },
            new Team { Name = "ECR12", Status = Status.Enabled },
            new Team { Name = "ECR13", Status = Status.Enabled },
            new Team { Name = "ECR14", Status = Status.Enabled },
            new Team { Name = "ECR15", Status = Status.Enabled },
            new Team { Name = "ECR16", Status = Status.Enabled },
            new Team { Name = "ECR17", Status = Status.Enabled },
            new Team { Name = "ECR18", Status = Status.Enabled },
            new Team { Name = "ECR19", Status = Status.Enabled },
            new Team { Name = "ECR20", Status = Status.Enabled },
            new Team { Name = "ECR21", Status = Status.Enabled },
            new Team { Name = "ECR22", Status = Status.Enabled },
            new Team { Name = "ECR23", Status = Status.Enabled },
            new Team { Name = "ECR24", Status = Status.Enabled },
            new Team { Name = "ECR25", Status = Status.Enabled },
            new Team { Name = "ECR29", Status = Status.Enabled },
            new Team { Name = "ECR26", Status = Status.Enabled },
            new Team { Name = "ECR27", Status = Status.Enabled },
            new Team { Name = "ECR30", Status = Status.Enabled },
            new Team { Name = "ECR28", Status = Status.Enabled },
            new Team { Name = "ECROS", Status = Status.Enabled },
            new Team { Name = "ECR31", Status = Status.Enabled },
            new Team { Name = "ECR32", Status = Status.Enabled },
            new Team { Name = "EBL01", Status = Status.Enabled },
            new Team { Name = "EBL02", Status = Status.Enabled },
            new Team { Name = "EBL03", Status = Status.Enabled },
            new Team { Name = "EBL04", Status = Status.Enabled },
            new Team { Name = "EBL05", Status = Status.Enabled },
            new Team { Name = "ECR33", Status = Status.Enabled },
            new Team { Name = "ESG01", Status = Status.Enabled },
            new Team { Name = "EIL01", Status = Status.Enabled },
            new Team { Name = "ENS01", Status = Status.Enabled },
            new Team { Name = "EUN01", Status = Status.Enabled },
            new Team { Name = "EUN02", Status = Status.Enabled },
            new Team { Name = "EBR01", Status = Status.Enabled },
            new Team { Name = "EBS01", Status = Status.Enabled },
            new Team { Name = "ECD01", Status = Status.Enabled },
            new Team { Name = "ECH01", Status = Status.Enabled },
            new Team { Name = "ECH02", Status = Status.Enabled },
            new Team { Name = "ECL01", Status = Status.Enabled },
            new Team { Name = "ECM01", Status = Status.Enabled },
            new Team { Name = "ECO01", Status = Status.Enabled },
            new Team { Name = "ECT01", Status = Status.Enabled },
            new Team { Name = "EDR01", Status = Status.Enabled },
            new Team { Name = "EED01", Status = Status.Enabled },
            new Team { Name = "EFL01", Status = Status.Enabled },
            new Team { Name = "EFR01", Status = Status.Enabled },
            new Team { Name = "EHN01", Status = Status.Enabled },
            new Team { Name = "EHN02", Status = Status.Enabled },
            new Team { Name = "ERS01", Status = Status.Enabled },
            new Team { Name = "ERZ01", Status = Status.Enabled },
            new Team { Name = "ESR01", Status = Status.Enabled },
            new Team { Name = "ECS01", Status = Status.Enabled },
            new Team { Name = "EOC01", Status = Status.Enabled },
            new Team { Name = "EGL01", Status = Status.Enabled },
            new Team { Name = "ECH03", Status = Status.Enabled },
            new Team { Name = "EVL01", Status = Status.Enabled },
            new Team { Name = "ECRY01", Status = Status.Enabled },
            new Team { Name = "ECB01", Status = Status.Enabled },
            new Team { Name = "ECB02", Status = Status.Enabled },
            new Team { Name = "ECB03", Status = Status.Enabled },
            new Team { Name = "ETB01", Status = Status.Enabled },
            new Team { Name = "ETB02", Status = Status.Enabled },
            new Team { Name = "ELV01", Status = Status.Enabled },
            new Team { Name = "EUN03", Status = Status.Enabled },
            new Team { Name = "EOR01", Status = Status.Enabled },
            new Team { Name = "EDN01", Status = Status.Enabled },
            new Team { Name = "ECR46", Status = Status.Enabled },
            new Team { Name = "ECR34", Status = Status.Enabled },
            new Team { Name = "ECR35", Status = Status.Enabled },
            new Team { Name = "ECR36", Status = Status.Enabled },
            new Team { Name = "ETL01", Status = Status.Enabled }
        };

        _context.Teams.AddRange(teams);

        await _context.SaveChangesAsync(cancellationToken);
    }
    
    private async Task SeedProcessAliasesAsync(CancellationToken cancellationToken)
    {
        var processAliases = new[]
        {
            new ProcessAlias { Name = "Conectari si schimb adresa" },
            new ProcessAlias { Name = "Adaugare echipamente aditionale" },
            new ProcessAlias { Name = "Reparatii" },
            new ProcessAlias { Name = "Pretrasare" },
        };

        _context.ProcessAliases.AddRange(processAliases);

        await _context.SaveChangesAsync(cancellationToken);
    }
    
    private async Task SeedProcessesAsync(CancellationToken cancellationToken)
    {
        var processes = new[]
        {
            new Process { Name = "Conectare client home", ProcessAliasId = 1 },
            new Process { Name = "Schimb adresa client home", ProcessAliasId = 1 },
            new Process { Name = "Adaugare echipament client home", ProcessAliasId = 2 },
            new Process { Name = "Reparatie client home", ProcessAliasId = 3 }
        };

        _context.Processes.AddRange(processes);

        await _context.SaveChangesAsync(cancellationToken);
    }
    
    private async Task SeedRegionsAsync(CancellationToken cancellationToken)
    {
        var regions = new[]
        {
            new TerritoryAlias { Name = "CHISINAU CENTRU"},
            new TerritoryAlias { Name = "CHISINAU CIOCANA"},
            new TerritoryAlias { Name = "CHISINAU BOTANICA"},
            new TerritoryAlias { Name = "CHISINAU BUIUCANI"},
            new TerritoryAlias { Name = "CHISINAU RASCANI"},
            new TerritoryAlias { Name = "UNGHENI"},
            new TerritoryAlias { Name = "BALTI"},
            new TerritoryAlias { Name = "BRICENI"},
            new TerritoryAlias { Name = "CAHUL"},
            new TerritoryAlias { Name = "CALARASI"},
            new TerritoryAlias { Name = "CAUSENI"},
            new TerritoryAlias { Name = "CEADAR-LUNGA"},
            new TerritoryAlias { Name = "CIMISLIA"},
            new TerritoryAlias { Name = "COMRAT"},
            new TerritoryAlias { Name = "DROCHIA"},
            new TerritoryAlias { Name = "EDINET"},
            new TerritoryAlias { Name = "FALESTI"},
            new TerritoryAlias { Name = "FLORESTI"},
            new TerritoryAlias { Name = "HANCESTI"},
            new TerritoryAlias { Name = "NISPORENI"},
            new TerritoryAlias { Name = "ORHEI"},
            new TerritoryAlias { Name = "RASCANI"},
            new TerritoryAlias { Name = "REZINA"},
            new TerritoryAlias { Name = "SOROCA"},
            new TerritoryAlias { Name = "STRASENI"},
            new TerritoryAlias { Name = "SINGEREI"},
            new TerritoryAlias { Name = "IALOVENI"},
            new TerritoryAlias { Name = "TARACLIA"},
            new TerritoryAlias { Name = "BASARABEASCA"},
            new TerritoryAlias { Name = "OCNITA"},
            new TerritoryAlias { Name = "GLODENI"},
            new TerritoryAlias { Name = "VULCANESTI"},
            new TerritoryAlias { Name = "CRIULENI"},
            new TerritoryAlias { Name = "LEOVA"},
            new TerritoryAlias { Name = "DONDUSENI"},
            new TerritoryAlias { Name = "TELENESTI"}
        };

        _context.TerritoryAliases.AddRange(regions);

        await _context.SaveChangesAsync(cancellationToken);
    }
    
    private async Task SeedTerritoriesAsync(CancellationToken cancellationToken)
    {
        var territories = new[]
        {
            new Territory { Name = "BALTI", RegionId = 7 },
            new Territory { Name = "BRICENI", RegionId = 8 },
            new Territory { Name = "CAHUL", RegionId = 9 },
            new Territory { Name = "CALARASI", RegionId = 10 },
            new Territory { Name = "CAUSENI", RegionId = 11 },
            new Territory { Name = "CEADAR", RegionId = 12 },
            new Territory { Name = "C_BAC", RegionId = 2 },
            new Territory { Name = "C_BACIOI", RegionId = 3 },
            new Territory { Name = "C_BOTANI", RegionId = 3 },
            new Territory { Name = "C_BUBUIE", RegionId = 2 },
            new Territory { Name = "C_BUDEST", RegionId = 2 },
            new Territory { Name = "C_BUIUCA", RegionId = 4 },
            new Territory { Name = "C_CENTRU", RegionId = 1 },
            new Territory { Name = "C_CHELTU", RegionId = 2 },
            new Territory { Name = "C_CIOCAN", RegionId = 2 },
            new Territory { Name = "C_CIORES", RegionId = 5 },
            new Territory { Name = "C_CODRU", RegionId = 3 },
            new Territory { Name = "C_COLONI", RegionId = 2 },
            new Territory { Name = "C_CRICOV", RegionId = 5 },
            new Territory { Name = "C_CRUZES", RegionId = 2 },
            new Territory { Name = "C_DUMBRA", RegionId = 4 },
            new Territory { Name = "C_DURLES", RegionId = 4 },
            new Territory { Name = "C_FLOREN", RegionId = 2 },
            new Territory { Name = "C_GHIDIG", RegionId = 4 },
            new Territory { Name = "C_GOIAN", RegionId = 5 },
            new Territory { Name = "C_GOIANU", RegionId = 5 },
            new Territory { Name = "C_GRATIE", RegionId = 5 },
            new Territory { Name = "C_HULBOA", RegionId = 5 },
            new Territory { Name = "C_RASCAN", RegionId = 5 },
            new Territory { Name = "C_SANGER", RegionId = 3 },
            new Territory { Name = "C_STAUCE", RegionId = 5 },
            new Territory { Name = "C_TELECE", RegionId = 1 },
            new Territory { Name = "C_TOHATI", RegionId = 2 },
            new Territory { Name = "C_TRUSEN", RegionId = 4 },
            new Territory { Name = "C_VADUL", RegionId = 2 },
            new Territory { Name = "C_VATRA", RegionId = 4 },
            new Territory { Name = "CIMISL", RegionId = 13 },
            new Territory { Name = "COMRAT", RegionId = 14 },
            new Territory { Name = "DROCHI", RegionId = 15 },
            new Territory { Name = "EDINET", RegionId = 16 },
            new Territory { Name = "FALEST", RegionId = 17 },
            new Territory { Name = "FLORES", RegionId = 18 },
            new Territory { Name = "HANCES", RegionId = 19 },
            new Territory { Name = "IALOVE", RegionId = 27 },
            new Territory { Name = "NISPOR", RegionId = 20 },
            new Territory { Name = "ORHEI", RegionId = 21 },
            new Territory { Name = "RASCAN", RegionId = 22 },
            new Territory { Name = "REZINA", RegionId = 23 },
            new Territory { Name = "SOROCA", RegionId = 24 },
            new Territory { Name = "STRASE", RegionId = 25 },
            new Territory { Name = "UNGHEN", RegionId = 6 },
            new Territory { Name = "SINGEREI", RegionId = 26 },
            new Territory { Name = "TARAC", RegionId = 28 },
            new Territory { Name = "BASARAB", RegionId = 29 },
            new Territory { Name = "OCNITA", RegionId = 30 },
            new Territory { Name = "GLODENI", RegionId = 31 },
            new Territory { Name = "VULC", RegionId = 32 },
            new Territory { Name = "CRIULENI", RegionId = 33 },
            new Territory { Name = "COJUSNA", RegionId = 4 },
            new Territory { Name = "LEOVA", RegionId = 34 },
            new Territory { Name = "DONDUSEN", RegionId = 35 },
            new Territory { Name = "TELENEST", RegionId = 36 }
        };

        _context.Territories.AddRange(territories);

        await _context.SaveChangesAsync(cancellationToken);
    }
}