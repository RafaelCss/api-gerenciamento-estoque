
using Dominio.Entidades.Root;
using Dominio.Interface;
using Infra.EF.Context;
using Infra.Repositorio;



namespace Infra.UOW;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppContexto _context;
    private readonly Dictionary<Type , object> _repositories;

    public UnitOfWork(AppContexto context)
    {
        _context = context;
        _repositories = new Dictionary<Type , object>();
    }

    public IRepositorio<T> Repositorio<T>() where T : AggregateRoot
    {
        var type = typeof(T);
        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(Repositorio<>).MakeGenericType(type);
            _repositories[type] = Activator.CreateInstance(repositoryType , _context);
        }

        return (IRepositorio<T>)_repositories[type];
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}
