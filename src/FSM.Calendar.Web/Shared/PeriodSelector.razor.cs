using Microsoft.AspNetCore.Components;

namespace FSM.Calendar.Web.Shared;

public partial class PeriodSelector
{
    private const string DateFormat = "yyyy-MM-dd";
    private const int WeekInterval = 8;
    private DateOnly FromDate { get; set; }
    private DateOnly ToDate { get; set; }
    
    [Parameter] public EventCallback<(DateOnly fromDate, DateOnly toDate)> PeriodSet { get; set; }

    protected override void OnInitialized()
    {
        FromDate = DateOnly.Parse("2022-07-28");
        ToDate = DateOnly.Parse("2022-08-04");
        PeriodSet.InvokeAsync((FromDate, ToDate));
        base.OnInitialized();
    }

    private void AddWeek()
    {
        FromDate = FromDate.AddDays(WeekInterval);
        ToDate = ToDate.AddDays(WeekInterval);
        PeriodSet.InvokeAsync((FromDate, ToDate));
    }
    
    private void SubtractWeek()
    {
        FromDate = FromDate.AddDays(-WeekInterval);
        ToDate = ToDate.AddDays(-WeekInterval);
        PeriodSet.InvokeAsync((FromDate, ToDate));
    }
}