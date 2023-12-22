using Autofac.Extensions.DependencyInjection;
using Autofac;
using PersonService.Api.Configurations.Abstraction;
using PersonService.Api.Configurations;
using PersonService.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InstallServices(
    builder.Configuration, typeof(IServiceInstaller).Assembly);


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionMiddleware();

app.UseHttpsRedirection();

app.UseCors();

app.MapControllers();

app.Run();
