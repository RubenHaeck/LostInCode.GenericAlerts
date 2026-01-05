using System.Threading.Tasks;

namespace LostInCode.GenericAlerts.Core.Interfaces;

public interface IScheduledAlertService
{
    Task ProcessDailyAlertsAsync();
    Task ProcessWeeklyAlertsAsync();
}
