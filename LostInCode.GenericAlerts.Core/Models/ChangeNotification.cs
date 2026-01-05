using LostInCode.GenericAlerts.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LostInCode.GenericAlerts.Core.Models;

public class ChangeNotification
{
    public string EntityType { get; set; } = string.Empty;
    public string EntityId { get; set; } = string.Empty;
    public ChangeType ChangeType { get; set; }
    public string ChangedBy { get; set; } = string.Empty;
    public DateTime ChangedAt { get; set; }
    public Dictionary<string, object>? Changes { get; set; }
}
