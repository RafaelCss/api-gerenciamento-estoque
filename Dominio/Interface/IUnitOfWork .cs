

using Dominio.Entidades.Root;

namespace Dominio.Interface;

public interface IUnitOfWork : IDisposable
{
    IRepositorio<T> Repositorio<T>() where T : AggregateRoot; // Para acessar repositórios genéricos
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}
