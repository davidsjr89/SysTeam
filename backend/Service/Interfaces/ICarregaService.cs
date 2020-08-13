using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface ICarregaService<T>
    {
        IList<T> Lista();
        T CarregaPor(T entity);
    }
}
