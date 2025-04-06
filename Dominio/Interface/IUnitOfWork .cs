

using Dominio.Entidades.Root;

namespace Dominio.Interface;

public interface IUnitOfWork : IDisposable
{
    IRepositorio<T> Repositorio<T>() where T : AggregateRoot; // Para acessar repositórios genéricos
    Task<int> SalvarAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}
