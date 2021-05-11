using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRIA.Portal.API.Base
{
    public class BaseController : ControllerBase
    {
        
        [NonAction]
        public ResponsePadrao<object> ResponseOk(object objetoRetorno = null, string mensagemRetorno = null)
        {
            return new ResponsePadrao<object>(true, mensagemRetorno, objetoRetorno);
        }

        [NonAction]
        public ResponsePadrao<Exception> ResponseError(Exception ex, string mensagemRetorno = null)
        {
            var mensagem = mensagemRetorno == null ? ex.Message : mensagemRetorno + " - " + ex.Message;

            return new ResponsePadrao<Exception>(false, mensagem, ex);
        }

        [NonAction]
        public ResponsePadrao<object> ResponseError(object objetoRetorno, string mensagemRetorno)
        {
            return new ResponsePadrao<object>(false, mensagemRetorno, objetoRetorno);
        }

        [NonAction]
        public ResponsePadrao<string> ResponseError(string error, string mensagemRetorno)
        {
            return new ResponsePadrao<string>(false, mensagemRetorno, error);
        }


        #region ResponsePadrao Json
        [NonAction]
        public JsonResult ResponseOkJson(object objetoRetorno = null, string mensagemRetorno = null)
        {
            return new JsonResult(ResponseOk(objetoRetorno, mensagemRetorno));
        }

        [NonAction]
        public JsonResult ResponseErrorJson(Exception ex, string mensagemRetorno = null)
        {
            return new JsonResult(ResponseError(ex, mensagemRetorno));
        }
        [NonAction]
        public JsonResult ResponseErrorJson(string erro, string mensagemRetorno = null)
        {
            return new JsonResult(ResponseError(erro, mensagemRetorno));
        }

        [NonAction]
        public JsonResult ResponseErrorJson(object objetoRetorno, string mensagemRetorno)
        {
            return new JsonResult(ResponseError(objetoRetorno, mensagemRetorno));
        }
        #endregion
    }
    public class ResponsePadrao<T> where T : class
    {
        public ResponsePadrao()
        {
        }

        public ResponsePadrao(bool isOk, string mensagemRetorno = null, T objetoRetorno = null)
        {
            if (IsList(objetoRetorno))
                mensagemRetorno = mensagemRetorno ?? $"Número de registros: {((IList)objetoRetorno).Count}";

            IsOk = isOk;
            MensagemRetorno = mensagemRetorno;
            ObjetoRetorno = objetoRetorno;
            
        }

        [JsonProperty("isOk")]
        public bool IsOk { get; set; }

        [JsonProperty("mensagemRetorno")]
        public string MensagemRetorno { get; set; }

        [JsonProperty("objetoRetorno")]
        public T ObjetoRetorno { get; set; }

        [JsonProperty("listagem")]
        public List<T> Listagem { get; set; }

        private bool IsList(object value)
        {
            if (value == null)
                return false;

            return value is IList || IsGenericList(value);
        }

        private bool IsGenericList(object value)
        {
            if (value == null)
                return false;

            var type = value.GetType();
            return type.IsGenericType && typeof(List<>) == type.GetGenericTypeDefinition();
        }
    }
}
