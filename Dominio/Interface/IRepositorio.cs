

using Dominio.Entidades.Root;

namespace Dominio.Interface;

public interface IRepositorio<T> where T : AggregateRoot
{
    Task<T?> GetByIdAsync(object id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
}
