using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Model.Autenticacao;
using Repositories.Data;
using Repositories.Interfaces;
using Repositories.Repository;
using Service.Interfaces;
using Service.Services;
using Service.Token;
using Xunit;

namespace Test.UserTest
{
    public class CarregaServiceUserTest
    {
        private readonly DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        private readonly ICarregaDAO<User> carregaDAO;
        private readonly ITokenService<User> tokenService;
        private readonly IPersistenciaService persistenciaService;
        private readonly IDAO dAO;

        public CarregaServiceUserTest()
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=SysTeam;User Id=sa;Password=123456;");
            tokenService = new TokenService();
            dAO = new PersistenciaDAO(new DataContext(optionsBuilder.Options));
            carregaDAO = new CarregaUserDAO(new DataContext(optionsBuilder.Options));
            persistenciaService = new PersistenciaService(dAO);
        }
        [Fact]
        public void CarregaServiceUser_CarregaPor_UserPassword()
        {
            User model = new User()
            {
                Username = "jho",
                Password = tokenService.Encrypt("jho"),
                Email = "jho@gmail.com",
                Ativo = true,
                Role = "manager"
            };
            persistenciaService.Add(model);

            User userPassword = new User()
            {
                Username = "jho",
                Password = tokenService.Encrypt("jho")
            };
            Assert.Equal(model.Id, carregaDAO.CarregaPor(userPassword).Id);
            persistenciaService.Remove(model);
        }
        [Fact]
        public void CarregaServiceUser_CarregarLista()
        {
            User model = new User()
            {
                Username = "jho",
                Password = tokenService.Encrypt("jho"),
                Email = "jho@gmail.com",
                Ativo = true,
                Role = "manager"
            };
            persistenciaService.Add(model);
            Assert.True(carregaDAO.Lista().Count > 0);
            persistenciaService.Remove(model);

        }
    }
}
