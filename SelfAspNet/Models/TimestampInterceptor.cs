using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SelfAspNet.Models;

public class TimestampInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
      DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateTimestamp(eventData.Context!);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateTimestamp(eventData.Context!);
        return base.SavingChangesAsync(eventData, result, cancellationToken);

    }

    private static void UpdateTimestamp(DbContext db)
    {
        var current = DateTime.Now;
        foreach (var e in db.ChangeTracker.Entries())
        {
            if (e.Entity is IRecordableTimestamp te)
            {
                switch (e.State)
                {
                    case EntityState.Added:
                        te.CreatedAt = current;
                        te.LastUpdatedAt = current;
                        break;
                    case EntityState.Modified:
                        te.LastUpdatedAt = current;
                        break;
                }
            }
        }
    }
}
