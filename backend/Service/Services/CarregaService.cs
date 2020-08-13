using Model.Autenticacao;
using Repositories.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class CarregaService : ICarregaService<User>
    {
        private readonly ICarregaDAO<User> _carregaDAO;
        public CarregaService(ICarregaDAO<User> carregaDAO)
        {
            _carregaDAO = carregaDAO;
        }
        public User CarregaPor(User entity)
        {
            return _carregaDAO.CarregaPor(entity);
        }

        public IList<User> Lista()
        {
            throw new NotImplementedException();
        }
    }
}
