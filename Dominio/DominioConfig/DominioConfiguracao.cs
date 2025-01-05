using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Dominio.DominioConfig;

public static class DominioConfiguracao
{
    public static IServiceCollection AddDominioConfiguracao(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
