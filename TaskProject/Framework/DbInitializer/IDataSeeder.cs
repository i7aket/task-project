using Microsoft.EntityFrameworkCore;

namespace TaskProject.Framework.DbInitializer;

public interface IDataSeeder<in TContext> where TContext : DbContext
{
    Task SeedAsync(TContext context);
}