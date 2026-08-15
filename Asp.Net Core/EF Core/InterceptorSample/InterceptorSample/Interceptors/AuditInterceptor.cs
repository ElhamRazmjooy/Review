using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace InterceptorSample.Interceptors
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, 
            InterceptionResult<int> result)
        {
            var context = eventData.Context;
            if (context == null) return base.SavingChanges(eventData, result);
            foreach (var entry in context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        Console.WriteLine($"Added: {entry.Entity.GetType().Name}");
                        break;
                    case EntityState.Modified:
                        Console.WriteLine($"Modified: {entry.Entity.GetType().Name}");
                        break;
                    case EntityState.Deleted:
                        Console.WriteLine($"Deleted: {entry.Entity.GetType().Name}");
                        break;
                }
            }
            return base.SavingChanges(eventData, result);
        }
    }
}
