using Infra.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Configuracao;

public static class InfraConfiguracao
{
    public static IServiceCollection AddInfraConfiguracao(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped<EntityDateInterceptor>();

        services.AddDbContext<AppContexto>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection") ,
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))
            )
            .EnableSensitiveDataLogging()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        return services;
    }
}

