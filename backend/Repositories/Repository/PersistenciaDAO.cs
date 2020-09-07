using Repositories.Data;
using Repositories.Interfaces;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class PersistenciaDAO : IDAO
    {
        private readonly DataContext _context;
        public PersistenciaDAO(DataContext context)
        {
            _context = context;
        }
        public bool Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
            return SaveChanges();
        }

        public bool SaveChanges()
        {
            return ( _context.SaveChanges()) > 0;
        }

        public bool Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            return SaveChanges();
        }
        public bool Remove<T>(T entity) where T: class
        {
            _context.Remove(entity);
            return SaveChanges();
        }

    }
}
