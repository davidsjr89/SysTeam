using Microsoft.EntityFrameworkCore;
using Model.Autenticacao;

namespace Repositories.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
