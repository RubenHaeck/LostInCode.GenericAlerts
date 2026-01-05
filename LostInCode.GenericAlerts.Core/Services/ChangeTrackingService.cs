using LostInCode.GenericAlerts.Core.Interfaces;
using LostInCode.GenericAlerts.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LostInCode.GenericAlerts.Core.Services;

public class ChangeTrackingService<TDbContext> : IChangeTrackingService
    where TDbContext : DbContext
{
    private readonly IDbContextFactory<TDbContext> _contextFactory;
    private readonly IAlertDispatcher _alertDispatcher;

    public ChangeTrackingService(IDbContextFactory<TDbContext> contextFactory, IAlertDispatcher alertDispatcher)
    {
        _contextFactory = contextFactory;
        _alertDispatcher = alertDispatcher;
    }

    public async Task TrackChangeAsync(ChangeNotification notification)
    {
        await _alertDispatcher.DispatchAsync(notification);
    }
}
