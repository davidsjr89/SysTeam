using Repositories.Interfaces;
using Repositories.Repository;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class PersistenciaService : IPersistenciaService
    {
        private readonly IDAO _dAO;
        public PersistenciaService(IDAO dAO)
        {
            _dAO = dAO;
        }
        public bool Add<T>(T entity) where T : class
        {
            return _dAO.Add(entity);
        }

        public bool Update<T>(T entity) where T : class
        {
            return _dAO.Update(entity);
        }
    }
}
