using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface ICarregaDAO<T>
    {
        List<T> Lista(T entity);
        T CarregaPor(T entity);
    }
}
