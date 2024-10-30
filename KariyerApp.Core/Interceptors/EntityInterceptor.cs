using KariyerApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace KariyerApp.Core.Interceptors
{
    public class EntityInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                if (entry.Entity is ICreatableEntity createableEntity && entry.State == EntityState.Added)
                {
                    createableEntity.CreatedDate = DateTime.Now;
                    createableEntity.CreatedBy = "1";
                }

                if (entry.Entity is IUpdateableEntity updateableEntity && entry.State == EntityState.Modified)
                {
                    updateableEntity.UpdatedDate = DateTime.Now;
                    updateableEntity.UpdatedBy = "1";
                }

                if (entry.Entity is IDeletableEntity deletableEntity && entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified; // Delete işlemini yumuşak silme olarak güncelle
                    deletableEntity.IsDeleted = true;
                    deletableEntity.UpdatedDate = DateTime.Now;
                    deletableEntity.UpdatedBy = "1";
                }
            }
        }
    }
}
