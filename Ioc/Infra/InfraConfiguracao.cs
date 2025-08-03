using Dominio.Interface;
using Infra.Configuracao;
using Infra.EF.Context;
using Infra.RabbitMQ;
using Infra.Repositorio;
using Infra.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfraConfiguracao
{
    public static IServiceCollection AddInfraConfiguracao(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped<EntityDateInterceptor>();
        services.AddScoped<IUnitOfWork , UnitOfWork>();
        services.AddRabbitMQProducer(configuration);
        services.AddScoped(typeof(IContextoLeitura<>) , typeof(ContextoLeitura<>));
        services.AddScoped(typeof(IRepositorio<>) , typeof(Repositorio<>));
        services.AddDbContext<AppContexto>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection") ,
               ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))
            )
            .EnableSensitiveDataLogging(false)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        );
        using (var serviceProvider = services.BuildServiceProvider())
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppContexto>();
                dbContext.Database.Migrate();
            }
        }


        return services;
    }
}

