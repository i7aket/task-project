using Microsoft.EntityFrameworkCore;

namespace TaskProject.Framework.DbInitializer;

public class DbInitializer<TContext>(IServiceProvider serviceProvider) : IDbInitializer<TContext>
    where TContext : DbContext
{
    public async Task InitializeAsync()
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        TContext context = scope.ServiceProvider.GetRequiredService<TContext>();
        ILogger<TContext> logger = scope.ServiceProvider.GetRequiredService<ILogger<TContext>>();
        IEnumerable<IDataSeeder<TContext>> seeders = scope.ServiceProvider.GetServices<IDataSeeder<TContext>>();

        try
        {
            await context.Database.MigrateAsync();
            
            foreach (IDataSeeder<TContext> seeder in seeders.OrderBy(s => s.GetType().Name))
            {
                await seeder.SeedAsync(context);
                logger.LogInformation("Executed seeder: {SeederName}", seeder.GetType().Name);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error during database initialization");
            throw;
        }
    }
}