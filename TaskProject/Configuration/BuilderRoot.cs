namespace TaskProject.Configuration;

public static class BuilderRoot
{
    public static void ConfigureBuilder(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile("appsettings.json", false, true);
        builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
        builder.Configuration.AddEnvironmentVariables();
    }
}