using System.Threading.Tasks;
using TRIA.Portal.Domain.DTO;
using TRIA.Portal.Domain.DTO.Auth;

namespace TRIA.Portal.Domain.Interfaces.Services
{
    public interface IUserService
    {

        Task<UserDTO> ConsultarUsuario(LoginDTO login);
        Task<UserDTO> CadastrarUsuario(UserDTO userDTO);
    }
}
