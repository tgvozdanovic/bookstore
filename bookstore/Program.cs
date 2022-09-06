using Microsoft.OpenApi.Models;
using Rhetos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null)
    ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("rest", new OpenApiInfo { Title = "Rhetos REST API", Version = "v1" });
});

builder.Services
    .AddRhetosHost((serviceProvider, rhetosHostBuilder) =>
    {
        rhetosHostBuilder
            .ConfigureRhetosAppDefaults()
            .UseBuilderLogProviderFromHost(serviceProvider)

            .ConfigureConfiguration(cfg => cfg.MapNetCoreConfiguration(builder.Configuration));
    })
    .AddRestApi(o =>
    {
        o.BaseRoute = "rest";
        o.GroupNameMapper = (conceptInfo, controller, oldName) => "rest";
    })
    .AddDashboard()
    .AddAspNetCoreIdentityUser()
    .AddHostLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/rest/swagger.json", "Rhetos REST API");
    });
    //app.MapRhetosDashboard("dash");
}
app.UseRhetosRestApi();
app.UseAuthorization();

app.MapControllers();

app.Run();