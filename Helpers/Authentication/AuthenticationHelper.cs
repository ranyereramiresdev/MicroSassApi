using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MicroSassApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace MicroSassApi.Helpers.Authentication
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        public string GenerateToken (UsuarioModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AuthenticationSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(type:"Id", user.Id.ToString()),
                    new Claim(type:"IdResponsavel", user.IdResponsavel.ToString()),
                    new Claim(type:ClaimTypes.Role, user.IdTipoUsuario.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
