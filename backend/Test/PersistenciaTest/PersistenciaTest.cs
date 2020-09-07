using Microsoft.EntityFrameworkCore;
using Model.Autenticacao;
using Repositories.Data;
using Repositories.Interfaces;
using Repositories.Repository;
using Service.Interfaces;
using Service.Services;
using Service.Token;
using Xunit;

namespace Test.PersistenciaTest
{
    public class PersistenciaTest
    {
        private readonly DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        private readonly IPersistenciaService persistenciaService;
        private readonly ITokenService<User> tokenService;
        private readonly IDAO dAO;
        public PersistenciaTest()
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=SysTeam;User Id=sa;Password=123456;");
            tokenService = new TokenService();
            dAO = new PersistenciaDAO(new DataContext(optionsBuilder.Options));
            persistenciaService = new PersistenciaService(dAO);
        }
        [Fact]
        public void Add_User()
        {
            User model = new User()
            {
                Username = "jho",
                Password = tokenService.Encrypt("jho"),
                Email = "jho@gmail.com",
                Ativo = true,
                Role = "manager"
            };
            Assert.True(persistenciaService.Add(model));
            persistenciaService.Remove(model);

        }
        [Fact]
        public void Update_User()
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

            model.Role = "teste";


            Assert.True(persistenciaService.Update(model));
            persistenciaService.Remove(model);


        }
        [Fact]
        public void Remove_User()
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
            Assert.True(persistenciaService.Remove(model));
        }
        
    }

}
