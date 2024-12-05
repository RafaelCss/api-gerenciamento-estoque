using Dominio.Entidade;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;

namespace Infra.EF;

public class AppContexto : DbContext
{
    private readonly EntityDateInterceptor _interceptor;

    public AppContexto(DbContextOptions<AppContexto> options, EntityDateInterceptor interceptor)
         : base(options) 
    {
        _interceptor = interceptor;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_interceptor);
        base.OnConfiguring(optionsBuilder);
    }


    public DbSet<Produto> Produtos { get; set; }

}
