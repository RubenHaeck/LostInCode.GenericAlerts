using LostInCode.GenericAlerts.Core.Configuration;
using LostInCode.GenericAlerts.Core.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LostInCode.GenericAlerts.Core.Services;

public class ScheduledAlertProcessor : BackgroundService
{
    private readonly IScheduledAlertService _scheduledAlertService;
    private readonly AlertsOptions _options;

    public ScheduledAlertProcessor(IScheduledAlertService scheduledAlertService, AlertsOptions options)
    {
        _scheduledAlertService = scheduledAlertService;
        _options = options;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);

            // TODO: Implement scheduled checking based on _options.ScheduledCheckTimeLocal
            // For now, just wait
        }
    }
}
