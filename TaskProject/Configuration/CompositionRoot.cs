using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;
using TaskProject.Components.Account;
using TaskProject.Data;
using TaskProject.Framework.DbInitializer;
using TaskProject.Services;

namespace TaskProject.Configuration;

public static class CompositionRoot
{
    public static void ConfigureServices(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment webHostEnvironment
    )
    {
        services
            .AddInfrastructure(configuration)
            .AddApplicationServices(configuration)
            .AddPresentationServices(configuration);
    }
    
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddScoped<ISocialNetworksService, SocialNetworksService>()
            .AddScoped<ICurrentUserService, CurrentUserService>()
            .AddAuthentication()
            .AddInstagram(instagramOptions =>
            {
                instagramOptions.ClientId = configuration["Authentication:Instagram:ClientId"];
                instagramOptions.ClientSecret = configuration["Authentication:Instagram:ClientSecret"];
                
                //TODO: AddScope, AddFields, Add saving of profile link to applicationuser
            })
            .AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                
                //TODO: AddScope, AddFields,  Add saving of profile link to applicationuser
            })
            .AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"];
                
                //TODO: AddScope, AddFields,  Add saving of profile link to applicationuser
            })
            .AddLinkedIn(linkedInOptions =>
            {
                linkedInOptions.ClientId = configuration["Authentication:LinkedIn:ClientId"];
                linkedInOptions.ClientSecret = configuration["Authentication:LinkedIn:ClientSecret"];
                
                //TODO: AddScope, AddFields,  Add saving of profile link to applicationuser
            });

        return services;
    }

    public static IServiceCollection AddPresentationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddRazorComponents()
            .AddInteractiveServerComponents();
        
        services
            .AddRadzenComponents()
            .AddServerSideBlazor();

        services
            .AddCascadingAuthenticationState()
            .AddScoped<IdentityUserAccessor>()
            .AddScoped<IdentityRedirectManager>()
            .AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

        services
            .AddControllers();

        services.AddDatabaseDeveloperPageExceptionFilter();
        services.AddHttpContextAccessor();

        return services;
    }

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>()
            .AddDbContext<ApplicationDbContext>(options =>
            {
                string connectionString = configuration.GetConnectionString("Postgres")
                                          ?? throw new InvalidOperationException(
                                              "Connection string 'Postgres' not found.");

                options.UseNpgsql(connectionString);
                options.EnableSensitiveDataLogging();
            }, ServiceLifetime.Transient)
            .AddDbInitializer<ApplicationDbContext>(configuration)
            .AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
                options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }


}