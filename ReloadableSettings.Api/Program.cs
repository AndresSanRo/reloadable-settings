using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using ReloadableSettings.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("AppConfig");

// Load configuration from Azure App Configuration
builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(connectionString)
            .Select(KeyFilter.Any, LabelFilter.Null)
            .ConfigureRefresh(refreshOptions =>
            {
                refreshOptions.Register("Sentinel", refreshAll: true).SetCacheExpiration(TimeSpan.FromSeconds(10));
            });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAzureAppConfiguration();

builder.Services.ConfigureSettings(builder.Configuration);
builder.Services.ConfigureDependencyInjection();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Local")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAzureAppConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
