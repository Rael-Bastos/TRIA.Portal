﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRIA.Portal.Domain.DTO.Auth
{
    public class TokenResponseModel
    {

        [JsonProperty(".expires")]
        public DateTime DataExpiracao { get; set; }

        [JsonProperty("access_token")]
        public string Token { get; set; }

        [JsonProperty("userName")]
        public string Usuario { get; set; }

        [JsonProperty("NomeCompleto")]
        public string NomeCompleto { get; set; }

        [JsonProperty("Perfil")]
        public string Perfil { get; set; }

        [JsonProperty("retornoNegado")]
        public TipoAcessoNegado AcessoNegado { get; set; }

        public enum TipoAcessoNegado
        {
            UsuarioNaoEncontrado = 1,
            SenhaIncorreta = 2,
            UsuarioInativo = 3
        }
    }
}
