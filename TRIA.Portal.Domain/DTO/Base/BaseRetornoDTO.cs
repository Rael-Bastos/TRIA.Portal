using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRIA.Portal.Domain.DTO
{
    public class BaseRetornoDTO
    {

        public BaseRetornoDTO()
        {

        }

        public BaseRetornoDTO(string mensagemRetorno)
        {
            _mensagemRetorno = mensagemRetorno;
        }

        private string _mensagemRetorno { get; set; }

        public void AtriburirMensagemRetorno(string mensagem)
        {
            _mensagemRetorno = mensagem;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MensagemRetorno { get { return _mensagemRetorno; } }
    }
}
