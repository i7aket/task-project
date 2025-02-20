using Microsoft.EntityFrameworkCore;

namespace TaskProject.Framework.DbInitializer;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbInitializer<TContext>(
        this IServiceCollection services,
        IConfiguration configuration)
        where TContext : DbContext
    {
        services.AddTransient<IDbInitializer<TContext>, DbInitializer<TContext>>();

        services.Scan(scan => scan 
            .FromApplicationDependencies()
            .AddClasses(classes => classes.AssignableTo(typeof(IDataSeeder<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}

