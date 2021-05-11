using System;
using System.Collections.Generic;
using System.Text;
using TRIA.Portal.Domain.Entity;

namespace TRIA.Portal.Domain.DTO
{
    public class UserDTO: BaseRetornoDTO
    {
        public UserDTO()
        {

        }
        public UserDTO(string mensagemRetorno) : base(mensagemRetorno)
        {
        }
        public UserDTO(User user)
        {
            Id = user.Id;
            Usuario = user.Username;
            Senha = user.Password;
            Perfil = user.Profile;
            NomeCompleto = user.NomeCompleto;
            Email = user.Email;
        }

        public int Id { get; set; }

        public string Usuario { get; set; }
        
        public string NomeCompleto { get; set; }
        
        public string Email { get; set; }

        public string Senha { get; set; }
        
        public string Perfil { get; set; }

        public static UserDTO ConverterDTO(User user)
        {
            return new UserDTO(user);
        }
    }
}
