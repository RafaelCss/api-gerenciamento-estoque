using Dominio.Entidades;
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

        // Aplica todas as configurações de entidades do assembly atual
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContexto).Assembly);
    }

    // Definição das entidades
    public DbSet<Produto> Produtos { get; set; }
}
