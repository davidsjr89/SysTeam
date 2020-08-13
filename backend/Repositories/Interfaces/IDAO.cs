namespace Repositories.Interfaces
{
    public interface IDAO
    {
        bool Add<T>(T entity) where T : class;
        bool Update<T>(T entity) where T : class;
        bool SaveChanges();
    }
}
