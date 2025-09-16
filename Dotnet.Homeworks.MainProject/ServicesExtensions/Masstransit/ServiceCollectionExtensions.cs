using Dotnet.Homeworks.MainProject.Configuration;
using MassTransit;
using Microsoft.Extensions.Options;

namespace Dotnet.Homeworks.MainProject.ServicesExtensions.Masstransit;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMasstransitRabbitMq(this IServiceCollection services)
    {
        var rabbitConfiguration = 
            services
                .BuildServiceProvider()
                .GetService<IOptions<RabbitMqConfig>>()!
                .Value;
        
        return services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            x.UsingRabbitMq((context, cfg) => 
            {
                cfg.Host(rabbitConfiguration.Hostname, h =>
                {
                    h.Username(rabbitConfiguration.Username);
                    h.Password(rabbitConfiguration.Password);
                });
                cfg.ConfigureEndpoints(context);
            });
        });
    }
}