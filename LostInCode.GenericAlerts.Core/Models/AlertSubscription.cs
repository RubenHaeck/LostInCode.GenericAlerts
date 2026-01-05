using LostInCode.GenericAlerts.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LostInCode.GenericAlerts.Core.Models;

[Table("AlertSubscriptions")]
public class AlertSubscription
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(200)]
    public string EntityType { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? EntityFilter { get; set; }

    public AlertFrequency Frequency { get; set; }

    [Required, MaxLength(256)]
    public string NotificationEmail { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
