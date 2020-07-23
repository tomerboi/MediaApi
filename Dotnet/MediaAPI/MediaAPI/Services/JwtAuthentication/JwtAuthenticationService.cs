using MediaAPI.Data;
using MediaAPI.Domain.Secret;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MediaAPI
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly DbConnector m_dbConnector; 
        public JwtAuthenticationService(DbConnector dbConnector)
        {
            m_dbConnector = dbConnector;
        }
        public async Task<string> AuthenticateAsync(string userName, string password)
        {
            if(!m_dbConnector.GetAllUsers().Any(x => x.UserName == userName && x.Password == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(Key.key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
