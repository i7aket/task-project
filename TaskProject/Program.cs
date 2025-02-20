using TaskProject.Configuration;
using TaskProject.Data;
using TaskProject.Framework.DbInitializer;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.ConfigureBuilder();

builder.Services.ConfigureServices(builder.Configuration, builder.Environment);

WebApplication app = builder.Build();

await app.InitializeDatabase<ApplicationDbContext>();

app.ConfigureMiddleware(app.Configuration, app.Environment);

await app.RunAsync();