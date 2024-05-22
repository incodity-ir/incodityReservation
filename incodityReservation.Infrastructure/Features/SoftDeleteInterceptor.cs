using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace incodityReservation.Infrastructure.Features
{
    public sealed class SoftDeleteInterceptor:SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            if(eventData.Context == null) 
                return base.SavingChangesAsync(eventData, result, cancellationToken);

            var _list = eventData.Context.ChangeTracker.Entries<ISoftDelete>()
                .Where(p => p.State == EntityState.Deleted);
            foreach (var item in _list)
            {
                item.State = EntityState.Modified;
                item.Entity.DeletedAt = DateTime.Now;
                item.Entity.IsDeleted = true;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
