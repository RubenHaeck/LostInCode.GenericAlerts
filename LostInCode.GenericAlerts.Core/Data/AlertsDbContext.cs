using LostInCode.GenericAlerts.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LostInCode.GenericAlerts.Core.Data;

public class AlertsDbContext : DbContext
{
    public AlertsDbContext(DbContextOptions<AlertsDbContext> options) : base(options)
    {
    }

    public DbSet<AlertSubscription> AlertSubscriptions { get; set; }
    public DbSet<EntityChange> EntityChanges { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AlertSubscription>(entity =>
        {
            entity.HasIndex(e => new { e.EntityType, e.Frequency });
        });

        modelBuilder.Entity<EntityChange>(entity =>
        {
            entity.HasIndex(e => new { e.EntityType, e.NotificationSent });
            entity.HasIndex(e => e.ChangedAt);
        });
    }
}
