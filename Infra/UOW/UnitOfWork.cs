using Infra.EF.Context;
using Infra.Repositorio;
using Infra.Repositorio.Interface;
using Infra.UOW.Interfaces;



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

    public IRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T);
        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(Repository<>).MakeGenericType(type);
            _repositories[type] = Activator.CreateInstance(repositoryType , _context);
        }

        return (IRepository<T>)_repositories[type];
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
