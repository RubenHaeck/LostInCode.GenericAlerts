using LostInCode.GenericAlerts.Core.Data;
using LostInCode.GenericAlerts.Core.Enums;
using LostInCode.GenericAlerts.Core.Interfaces;
using LostInCode.GenericAlerts.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LostInCode.GenericAlerts.Core.Services;

public class AlertDispatcher : IAlertDispatcher
{
    private readonly IDbContextFactory<AlertsDbContext> _contextFactory;

    public AlertDispatcher(IDbContextFactory<AlertsDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task DispatchAsync(ChangeNotification notification)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        var entityChange = new EntityChange
        {
            EntityType = notification.EntityType,
            EntityId = notification.EntityId,
            ChangeType = notification.ChangeType,
            ChangedBy = notification.ChangedBy,
            ChangedAt = notification.ChangedAt,
            ChangesJson = notification.Changes != null ? JsonSerializer.Serialize(notification.Changes) : null,
            NotificationSent = false
        };

        context.EntityChanges.Add(entityChange);
        await context.SaveChangesAsync();

        await ProcessInstantAlertsAsync(entityChange);
    }

    public async Task ProcessInstantAlertsAsync(EntityChange change)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        var instantSubs = await context.AlertSubscriptions
            .Where(s => s.EntityType == change.EntityType && s.Frequency == AlertFrequency.Instant)
            .ToListAsync();

        // TODO: Send instant alerts via email
        if (instantSubs.Any())
        {
            change.NotificationSent = true;
            context.EntityChanges.Update(change);
            await context.SaveChangesAsync();
        }
    }
}
