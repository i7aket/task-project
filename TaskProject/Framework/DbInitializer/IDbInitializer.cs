using Microsoft.EntityFrameworkCore;

namespace TaskProject.Framework.DbInitializer;

public interface IDbInitializer<TContext> where TContext : DbContext
{
    Task InitializeAsync();
}