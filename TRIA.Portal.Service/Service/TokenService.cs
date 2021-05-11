using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TRIA.Portal.Domain.DTO;
using TRIA.Portal.Domain.DTO.Auth;
using TRIA.Portal.Domain.Interfaces.Services;
using TRIA.Portal.Domain.Settings;

namespace TRIA.Portal.Service.Service
{
    public class TokenService: ITokenService
    {
        public TokenResponseModel GerarToken(UserDTO user)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Settings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Usuario.ToString()),
                        new Claim(ClaimTypes.Role, user.Perfil.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return new TokenResponseModel() {
                    Usuario = user.Usuario,
                    DataExpiracao = tokenDescriptor.Expires.Value,
                    Token = tokenHandler.WriteToken(token),
                    NomeCompleto = user.NomeCompleto,
                    Perfil = user.Perfil,
                };

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
