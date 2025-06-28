using Dominio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Microsoft.Extensions.DependencyInjection;

public static class DominioConfiguracao
{
    public static IServiceCollection AddDominioConfiguracao(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Metadado.GetAssembly()));
        return services;
    }
}
