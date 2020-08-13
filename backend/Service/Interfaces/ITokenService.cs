using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITokenService<T>
    {
        string GenerateToken(T entity);
        string Encrypt(string password);
        string Decrypt(string password);
    }
}
