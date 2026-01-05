using LostInCode.GenericAlerts.Core.Models;
using System.Threading.Tasks;

namespace LostInCode.GenericAlerts.Core.Interfaces;

public interface IChangeTrackingService
{
    Task TrackChangeAsync(ChangeNotification notification);
}
