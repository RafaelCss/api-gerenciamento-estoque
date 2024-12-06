
using Infra.Repositorio.Interface;

namespace Infra.UOW.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : class; // Para acessar repositórios genéricos
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}
