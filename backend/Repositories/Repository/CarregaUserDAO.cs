using Model.Autenticacao;
using Repositories.Data;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Repository
{
    public class CarregaUserDAO : ICarregaDAO<User>
    {
        private readonly DataContext _dataContext;
        public CarregaUserDAO(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public User CarregaPor(User entity)
        {
            if (entity.Id == 0)
            {
                if (string.IsNullOrEmpty(entity.Email))
                    return _dataContext.Users.FirstOrDefault(x => x.Username == entity.Username && x.Password == entity.Password);
                else
                    return _dataContext.Users.FirstOrDefault(x => x.Username == entity.Username || x.Email == entity.Email);
            }
            else
            if (!string.IsNullOrEmpty(entity.Email))
                return _dataContext.Users.FirstOrDefault(x => x.Username == entity.Username && x.Email == entity.Email);
            return _dataContext.Users.FirstOrDefault(x => x.Username == entity.Username && x.Password == entity.Password);
        }

        public List<User> Lista(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
