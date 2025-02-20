using Microsoft.EntityFrameworkCore;

namespace TaskProject.Framework.DbInitializer;

public static class WebApplicationInitializerExtension
{
    public static async Task InitializeDatabase<TContext>( 
        this WebApplication app) where TContext : DbContext
    {
        ArgumentNullException.ThrowIfNull(app);

        using IServiceScope scope = app.Services.CreateScope();
        IDbInitializer<TContext> initializer = scope.ServiceProvider
            .GetRequiredService<IDbInitializer<TContext>>();
            
        await initializer.InitializeAsync();
    }
}