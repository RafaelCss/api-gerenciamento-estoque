﻿using Infra.EF.Context;
using Infra.Repositorio;
using Infra.Repositorio.Interface;
using Infra.UOW;
using Infra.UOW.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Configuracao;

public static class InfraConfiguracao
{
    public static IServiceCollection AddInfraConfiguracao(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped<EntityDateInterceptor>();
        services.AddScoped<IUnitOfWork , UnitOfWork>();

        services.AddScoped(typeof(IRepository<>) , typeof(Repository<>));
        services.AddDbContext<AppContexto>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection") ,
                new MySqlServerVersion(new Version(8 , 0 , 33)) // Substitua pela versão do seu MySQL
            )
            .EnableSensitiveDataLogging()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        );


        // Criar o banco automaticamente
        using (var serviceProvider = services.BuildServiceProvider())
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppContexto>();

                // Usa EnsureCreated ou Migrate, dependendo do cenário
                // dbContext.Database.EnsureCreated(); // Para cenários simples (não recomendado com migrações)
                dbContext.Database.Migrate(); // Aplica migrações pendentes
            }
        }


        return services;
    }
}

