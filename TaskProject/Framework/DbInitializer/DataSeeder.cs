using Microsoft.EntityFrameworkCore;

namespace TaskProject.Framework.DbInitializer;

public abstract class DataSeeder<TContext, TEntity> : IDataSeeder<TContext> 
    where TContext : DbContext
    where TEntity : class
{
    public async Task SeedAsync(TContext context)
    {
        if (!await context.Set<TEntity>().AnyAsync())
        {
            List<TEntity> entities = GetSeedData();
            await context.Set<TEntity>().AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }
    }

    protected abstract List<TEntity> GetSeedData();
}