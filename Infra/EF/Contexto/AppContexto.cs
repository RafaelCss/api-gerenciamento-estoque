using Dominio.Entidades;
using Flunt.Notifications;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;

namespace Infra.EF.Context;

public class AppContexto : DbContext
{
    private readonly EntityDateInterceptor _interceptor;

    // Construtor
    public AppContexto(DbContextOptions<AppContexto> options , EntityDateInterceptor interceptor)
        : base(options)
    {
        _interceptor = interceptor;
    }

    // Configuração de interceptadores (se necessário)
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_interceptor);
        base.OnConfiguring(optionsBuilder);
    }

    // Configuração do modelo
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Ignorar propriedades do Notifiable<Notification>
        modelBuilder.Ignore<Notification>();

        // Iterar pelas entidades que implementam Notifiable<Notification>
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(Notifiable<Notification>).IsAssignableFrom(entityType.ClrType))
            {
                // Ignorar as propriedades que o EF Core não consegue mapear
                modelBuilder.Entity(entityType.ClrType).Ignore("Notifications");
                modelBuilder.Entity(entityType.ClrType).Ignore("Valid");
                modelBuilder.Entity(entityType.ClrType).Ignore("Invalid");
            }
        }

        // Aplica todas as configurações de entidades do assembly atual
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContexto).Assembly);
    }

    // Definição das entidades
    public DbSet<Produto> Produtos { get; set; }
}
