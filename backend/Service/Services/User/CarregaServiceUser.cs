using Model.Autenticacao;
using Repositories.Interfaces;
using Service.Interfaces;
using System.Collections.Generic;

namespace Service.Services
{
    public class CarregaServiceUser : ICarregaService<User>
    {
        private readonly ICarregaDAO<User> _carregaDAO;
        public CarregaServiceUser(ICarregaDAO<User> carregaDAO)
        {
            _carregaDAO = carregaDAO;
        }
        public User CarregaPor(User entity)
        {
            return _carregaDAO.CarregaPor(entity);
        }

        public IList<User> Lista()
        {
            return _carregaDAO.Lista();
        }
    }
}
