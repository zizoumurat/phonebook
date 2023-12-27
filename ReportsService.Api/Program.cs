using Microsoft.OpenApi.Models;
using ReportsService.Api.Configurations;
using ReportsService.Api.Configurations.Abstraction;
using ReportsService.Application.Services;
using ReportsService.Infrasturcture;
using ReportsService.Infrasturcture.Hubs;
using ReportsService.Infrasturcture.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InstallServices(
    builder.Configuration, typeof(IServiceInstaller).Assembly);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Report API", Version = "v1" });
});


builder.Services.AddMassTransitWithRabbitMQ(builder.Configuration);
builder.Services.AddScoped<IReportQueueService, ReportQueueService>();

builder.Services.AddHttpClient("UserServiceClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["UserServiceBaseUrl"]);
});

builder.Services.AddScoped<IHttpClientService, HttpClientService>();

builder.Services.AddSignalR();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Report API V1");
    });
}

app.MapHub<NotificationHub>("/notificationhub");


app.UseHttpsRedirection();

app.UseCors();

app.MapControllers();

app.Run();
