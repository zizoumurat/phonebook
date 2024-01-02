using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportsService.Infrasturcture.Consumers;

namespace ReportsService.Infrasturcture
{
    public static class MassTransitSetup
    {
        public static IServiceCollection AddMassTransitWithRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<CreateReportConsumer>();
                x.AddConsumer<ProcessReportConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabbitMQ:Host"], "/", host =>
                    {
                        host.Username(configuration["RabbitMQ:UserName"]);
                        host.Password(configuration["RabbitMQ:Password"]);
                    });
                
                    cfg.ReceiveEndpoint("create_report_queue", e =>
                    {
                        e.ConfigureConsumer<CreateReportConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("process_report_queue", e =>
                    {
                        e.ConfigureConsumer<ProcessReportConsumer>(context);
                    });
                });
            });

            services.AddHostedService<MassTransitHostedService>();

            return services;
        }
    }
}
