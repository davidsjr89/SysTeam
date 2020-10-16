using Microsoft.EntityFrameworkCore;
using Model.Autenticacao;
using Repositories.Data;
using Repositories.Interfaces;
using Repositories.Repository;

namespace Teste
{
    public class Modelo
    {
        private readonly DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        private readonly ICarregaDAO<User> carregaDAO;

        public Modelo()
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=SysTeam;User Id=sa;Password=123456;");
            carregaDAO = new CarregaUserDAO(new DataContext(optionsBuilder.Options));
        }
    }
}
