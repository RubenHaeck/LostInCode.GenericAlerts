using LostInCode.GenericAlerts.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LostInCode.GenericAlerts.Core.Models;

public class AlertSubscriptionDto
{
    public Guid? Id { get; set; }
    public string EntityType { get; set; } = string.Empty;
    public string? EntityFilter { get; set; }
    public AlertFrequency Frequency { get; set; }
    public string NotificationEmail { get; set; } = string.Empty;
}
