using Microsoft.EntityFrameworkCore;
using Model.Autenticacao;
using NUnit.Framework;
using Repositories.Data;
using Repositories.Interfaces;
using Repositories.Repository;
using Service.Interfaces;
using Service.Services;
using Service.Token;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.BD;

namespace Teste.UserTest
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
            optionsBuilder.UseSqlServer(ConfiguracaoSQLServer.StringDeConexao());
            tokenService = new TokenService();
            dAO = new PersistenciaDAO(new DataContext(optionsBuilder.Options));
            carregaDAO = new CarregaUserDAO(new DataContext(optionsBuilder.Options));
            persistenciaService = new PersistenciaService(dAO);
        }
        [Test]
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
            Assert.AreEqual(model.Id, carregaDAO.CarregaPor(userPassword).Id);
            persistenciaService.Remove(model);
        }
        [Test]
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
