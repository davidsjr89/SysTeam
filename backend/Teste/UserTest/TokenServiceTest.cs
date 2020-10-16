using Microsoft.EntityFrameworkCore;
using Model.Autenticacao;
using NUnit.Framework;
using Repositories.Data;
using Repositories.Interfaces;
using Repositories.Repository;
using Service.Interfaces;
using Service.Token;
using Teste.BD;

namespace Teste.UserTest
{
    public class TokenServiceTest
    {
        private readonly DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        private readonly ICarregaDAO<User> carregaDAO;
        private readonly ITokenService<User> tokenService;


        public TokenServiceTest()
        {
            tokenService = new TokenService();
            optionsBuilder.UseSqlServer(ConfiguracaoSQLServer.StringDeConexao());
            carregaDAO = new CarregaUserDAO(new DataContext(optionsBuilder.Options));
        }

        [Test]
        public void TokenService_Encrypt()
        {
            var model = new User()
            {
                Username = "david1",
                Password = "123456"
            };
            model.Password = tokenService.Encrypt(model.Password);
            Assert.AreEqual("MTIzNDU2Mjg3NTZmNWZmOTJhNTUzYjM4OGZkZDRhMWNhZTc0ZmI=", model.Password);
        }
        [Test]
        public void TokenService_Decrypt()
        {

            var model = new User()
            {
                Username = "david1",
                Password = "MTIzNDU2Mjg3NTZmNWZmOTJhNTUzYjM4OGZkZDRhMWNhZTc0ZmI="
            };
            model.Password = tokenService.Decrypt(model.Password);
            Assert.AreEqual("123456", model.Password);
        }
        [Test]
        public void Settings_Token()
        {
            Assert.AreEqual("E462703AF506A53A6AD8278B97C9A0A0F48F41D95B3CD1937B0AC6ABFDA7863F", Settings.Secret);
        }
    }
}
