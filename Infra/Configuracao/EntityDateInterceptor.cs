using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidade.Base;


namespace Infra.Configuracao;

public class EntityDateInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData ,
        InterceptionResult<int> result)
    {
        AtualizarDatas(eventData);
        return base.SavingChanges(eventData , result); // Mantém o retorno como InterceptionResult<int>
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData ,
        InterceptionResult<int> result ,
        CancellationToken cancellationToken = default)
    {
        AtualizarDatas(eventData);
        return base.SavingChangesAsync(eventData , result , cancellationToken); // Mantém o retorno como InterceptionResult<int>
    }

    private void AtualizarDatas(DbContextEventData eventData)
    {
        if (eventData.Context is not DbContext context)
            return;

        var entries = context.ChangeTracker
            .Entries<EntidadeBase>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            var entity = entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.DataCriacao = DateTime.UtcNow;
            }

            entity.DataAtualizacao = DateTime.UtcNow;
        }
    }
}