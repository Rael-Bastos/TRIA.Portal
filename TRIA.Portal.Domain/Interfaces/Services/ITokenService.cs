using TRIA.Portal.Domain.DTO;
using TRIA.Portal.Domain.DTO.Auth;

namespace TRIA.Portal.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        TokenResponseModel GerarToken(UserDTO user);
    }
}
