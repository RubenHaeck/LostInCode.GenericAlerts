using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LostInCode.GenericAlerts.Core.Configuration;

public class AlertsOptions
{
    // Connection string: consumer kan zelf DbContext registreren of je helper overloads gebruiken
    public string? ConnectionString { get; set; }

    // If true, the library will register AlertsDbContext for you using the ConnectionString.
    public bool RegisterDbContext { get; set; } = false;

    // If RegisterDbContext is true, choose provider - only one implemented helper now (SqlServer).
    public bool UseSqlServer { get; set; } = true;

    // Cron or schedule for the background processor. If null, background processor uses internal default.
    // Format convention: "HH:mm" local time check window or Cron expression if you implement a cron runner.
    public string? ScheduledCheckTimeLocal { get; set; } = "19:00";

    // Timezone identifier to interpret ScheduledCheckTimeLocal (Windows/Linux differences)
    public string? TimeZoneId { get; set; } = "W. Europe Standard Time";

    // Allow consumers to add additional DI registrations in case they want to override IEmailService etc.
    public Action<IServiceCollection>? ConfigureServices { get; set; }

    // Feature flags
    public bool EnableInstantAlerts { get; set; } = true;
    public bool EnableScheduledAlerts { get; set; } = true;

    // Package version metadata (optional, useful for diagnostics)
    public string? LibraryVersion { get; set; }
}
