using LostInCode.GenericAlerts.Core.Interfaces;
using System.Threading.Tasks;

namespace LostInCode.GenericAlerts.Core.Services;

public class ScheduledAlertService : IScheduledAlertService
{
    public Task ProcessDailyAlertsAsync()
    {
        // TODO: Implement daily alerts processing logic
        return Task.CompletedTask;
    }

    public Task ProcessWeeklyAlertsAsync()
    {
        // TODO: Implement weekly alerts processing logic
        return Task.CompletedTask;
    }
}
