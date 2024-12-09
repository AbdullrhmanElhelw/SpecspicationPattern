using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SpecspicationPattern.Api.Models.Shared;

namespace SpecspicationPattern.Api.Data.Interceptors;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var entries = eventData.Context?.ChangeTracker
            .Entries()
            .Where(x => x is { Entity: Entity, State: EntityState.Deleted });

        if (entries is null)
            return base.SavingChanges(eventData, result);

        foreach (var entry in entries)
        {
            entry.State = EntityState.Modified;
            entry.CurrentValues["IsDeleted"] = true;
        }

        return base.SavingChanges(eventData, result);
    }
}