using Dominio.Entidades.Base;

namespace Dominio.Interface
{
    public interface IContextoLeitura<T> where T : Entidade
    {
        IQueryable<T> Query();
    }
}
