using System.Collections.Generic;

namespace Repositories.Interfaces
{
    public interface ICarregaDAO<T>
    {
        List<T> Lista();
        T CarregaPor(T entity);
    }
}
