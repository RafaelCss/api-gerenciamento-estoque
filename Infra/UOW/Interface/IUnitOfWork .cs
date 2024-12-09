

using Dominio.Entidades.Root;
using Infra.Repositorio.Interface;

namespace Infra.UOW.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepositorio<T> Repositorio<T>() where T : AggregateRoot; // Para acessar repositórios genéricos
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}
