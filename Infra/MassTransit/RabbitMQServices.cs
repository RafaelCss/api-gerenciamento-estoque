using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MassTransit;
using Dominio.Consumer;

namespace Infra.RabbitMQ;

public static class RabbitMQServices 
{
    public static void AddRabbitMQProducer(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {


            // x.AddConsumer<ProdutoConsumerEvento>(); 

            // Resgistra todos os consumidores de eventos que estão nas assemblies do domínio e infra
            x.AddConsumers(Dominio.Metadado.GetAssembly());

            x.UsingRabbitMq((context , cfg) =>
            {
                cfg.Host(configuration["RabbitMQ:Host"] , "/" , h =>
                {
                    h.Username(configuration["RabbitMQ:Username"]);
                    h.Password(configuration["RabbitMQ:Password"]);
                });
                cfg.ConfigureEndpoints(context);
            });
        });

    }
}

