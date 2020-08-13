using Microsoft.IdentityModel.Tokens;
using Model.Autenticacao;
using Service.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Token
{
    public  class TokenService: ITokenService<User>
    {
        private readonly string key = "28756f5ff92a553b388fdd4a1cae74fb";

        public string Decrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            var base64Encode64Bytes = Convert.FromBase64String(password);
            var result = Encoding.UTF8.GetString(base64Encode64Bytes);
            return result.Substring(0, result.Length - key.Length);
        }
        public string Encrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password += key;
            var passwordsBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordsBytes);
        }
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = 
                new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
