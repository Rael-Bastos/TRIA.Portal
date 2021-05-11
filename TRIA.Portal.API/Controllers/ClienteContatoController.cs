using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TRIA.Portal.API.Base;
using TRIA.Portal.Domain.DTO;
using TRIA.Portal.Domain.Interfaces.Services;

namespace TRIA.Portal.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ClienteContatoController : BaseController
    {
        private readonly IClienteContatoService _clienteContatoService;

        public ClienteContatoController(IClienteContatoService clienteContato)
        {
            _clienteContatoService = clienteContato;
            
        }
       

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] ClienteContatoDTO ClienteContato)
        {
            try
            {
                var retorno = await _clienteContatoService.Inserir(ClienteContato);
                if (!string.IsNullOrEmpty(retorno.MensagemRetorno))
                    return ResponseErrorJson("", retorno.MensagemRetorno);

                return ResponseOkJson(retorno, "Cliente Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Alterar([FromBody] ClienteContatoDTO ClienteContato)
        {
            try
            {
                var retorno = await _clienteContatoService.Alterar(ClienteContato);
                if (!string.IsNullOrEmpty(retorno.MensagemRetorno))
                    return ResponseErrorJson("", retorno.MensagemRetorno);

                return ResponseOkJson(retorno, "Cliente Alterado com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var retorno = await _clienteContatoService.Excluir(id);
                if (!string.IsNullOrEmpty(retorno.MensagemRetorno))
                    return ResponseErrorJson("", retorno.MensagemRetorno);

                return ResponseOkJson(retorno, "Cliente contato deletado com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            try
            {
                var retorno = await _clienteContatoService.ConsultarPorId(id);

                return ResponseOkJson(retorno, "Consulta realizada com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        public async Task<IActionResult> ConsultarTodos()
        {
            try
            {
                var retorno = await _clienteContatoService.ConsultarClientes();

                return ResponseOkJson(retorno, "Consulta realizada com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
