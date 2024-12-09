using Dominio.Entidades.Base;

namespace Infra.Repositorio.Interface
{
    public interface IContextoLeitura<T> where T : Entidade
    {
        IQueryable<T> Query();
    }
}
