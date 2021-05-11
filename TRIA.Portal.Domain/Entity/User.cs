using System;
using System.Collections.Generic;
using System.Text;
using TRIA.Portal.Domain.DTO;

namespace TRIA.Portal.Domain.Entity
{
    public class User
    {
        public User()
        {

        }
        public User(UserDTO userDTO)
        {
            Id = userDTO.Id;
            Username = userDTO.Usuario;
            NomeCompleto = userDTO.NomeCompleto;
            Email = userDTO.Email;
            Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Senha);
            Profile = userDTO.Perfil;
            DtInclusao = DateTime.Now;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Profile { get; set; }

        public DateTime DtInclusao { get; set; }
    }
}
