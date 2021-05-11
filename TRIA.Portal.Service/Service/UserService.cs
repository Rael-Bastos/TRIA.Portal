using System;
using System.Linq;
using System.Threading.Tasks;
using TRIA.Portal.Domain.DTO;
using TRIA.Portal.Domain.DTO.Auth;
using TRIA.Portal.Domain.Entity;
using TRIA.Portal.Domain.Interfaces.Repository;
using TRIA.Portal.Domain.Interfaces.Services;

namespace TRIA.Portal.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _userRepository = userRepository;

        }
       public async Task<UserDTO> ConsultarUsuario(LoginDTO login)
        {
            try
            {
                var user = await _userRepository.ConsultaPersonalizada(x => x.Username.Equals(login.UserName) || x.Email.Equals(login.UserName));
                if (user != null && user.Count > 0)
                {
                    var usuario = user.FirstOrDefault();
                    if(BCrypt.Net.BCrypt.Verify(login.Password, usuario.Password))
                        return UserDTO.ConverterDTO(usuario);
                    else
                        return new UserDTO("Senha Incorreta");
                }
                    
                else
                    return new UserDTO("Usuario não cadastrado no sistema");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<UserDTO> CadastrarUsuario(UserDTO userDTO)
        {
            try
            {
                var retorno = await _userRepository.Inserir(new User(userDTO));
                _uow.SaveChanges();
                if (retorno > 0)
                    return new UserDTO();
                else
                    return new UserDTO("Erro ao inserir Usuario");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
