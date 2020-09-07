namespace Service.Interfaces
{
    public interface IPersistenciaService
    {
        bool Add<T>(T entity) where T : class;
        bool Update<T>(T entity) where T : class;
        bool Remove<T>(T entity) where T : class;
    }
}