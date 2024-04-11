using incodityReservation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace incodityReservation.Infrastructure.Features
{
    public sealed class SoftDeleteInterceptor:SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            if (eventData.Context == null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            IEnumerable<EntityEntry<ISoftDelete>> entities = eventData.Context.ChangeTracker.Entries<ISoftDelete>()
                .Where(e => e.State == EntityState.Deleted);
            foreach (var item in entities)
            {
                item.State = EntityState.Modified;
                item.Entity.IsDeleted = true;
                item.Entity.DeletedAt = DateTime.UtcNow;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);

        }
    }
}
