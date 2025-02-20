using TaskProject.Components;

namespace TaskProject.Configuration;

internal static class Pipeline
{
    public static void ConfigureMiddleware(
        this WebApplication app,
        IConfiguration configuration,
        IWebHostEnvironment env
    )
    {
        ArgumentNullException.ThrowIfNull(app);
        ArgumentNullException.ThrowIfNull(configuration);
        ArgumentNullException.ThrowIfNull(env);

        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            app.UseHsts();
        }
        
        app.UseHttpsRedirection()
            .UseStaticFiles()
            .UseRouting()
            .UseAuthentication()
            .UseAuthorization()
            .UseAntiforgery();

        app.MapAdditionalIdentityEndpoints();

        app.MapControllers();
        
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();
    }
}