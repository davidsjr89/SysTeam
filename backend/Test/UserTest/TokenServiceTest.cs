using Microsoft.EntityFrameworkCore;
using Model.Autenticacao;
using Repositories.Data;
using Repositories.Interfaces;
using Repositories.Repository;
using Service.Interfaces;
using Service.Token;
using Xunit;

namespace Test
{
    public class TokenServiceTest
    {
        private readonly DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        private readonly ICarregaDAO<User> carregaDAO;
        private readonly ITokenService<User> tokenService;

        
        public TokenServiceTest()
        {
            tokenService = new TokenService();
            optionsBuilder.UseSqlServer("Server=localhost;Database=SysTeam;User Id=sa;Password=123456;");
            carregaDAO = new CarregaUserDAO(new DataContext(optionsBuilder.Options));
        }

        [Fact]
        public void TokenService_Encrypt()
        {
            var model = new User()
            {
                Username = "david1",
                Password = "123456"
            };
            model.Password = tokenService.Encrypt(model.Password);
            Assert.Equal("MTIzNDU2Mjg3NTZmNWZmOTJhNTUzYjM4OGZkZDRhMWNhZTc0ZmI=", model.Password);
        }
        [Fact]
        public void TokenService_Decrypt()
        {

            var model = new User()
            {
                Username = "david1",
                Password = "MTIzNDU2Mjg3NTZmNWZmOTJhNTUzYjM4OGZkZDRhMWNhZTc0ZmI="
            };
            model.Password = tokenService.Decrypt(model.Password);
            Assert.Equal("123456", model.Password);
        }
        [Fact]
        public void Settings_Token()
        {
            Assert.Equal("E462703AF506A53A6AD8278B97C9A0A0F48F41D95B3CD1937B0AC6ABFDA7863F", Settings.Secret);
        }
    }
}
