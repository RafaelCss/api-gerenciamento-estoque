using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infra.Configuracao
{
    public interface IEntityDateInterceptor
    {
        int SavingChanges(DbContextEventData eventData , InterceptionResult<int> result);
        ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData , InterceptionResult<int> result , CancellationToken cancellationToken = default);
    }
}