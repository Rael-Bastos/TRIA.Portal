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
    public class ProdutoServicoController : BaseController
    {
        private readonly IProdutoServicoService _produtoServicoService;
        private readonly ITokenService _tokenService;
        public ProdutoServicoController(IProdutoServicoService produtoServico,
            ITokenService tokenService)
        {
            _produtoServicoService = produtoServico;
            _tokenService = tokenService;
        }


        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] ProdutoServicoDTO produtoServico)
        {
            try
            {
                var retorno = await _produtoServicoService.Inserir(produtoServico);
                if (!string.IsNullOrEmpty(retorno.MensagemRetorno))
                    return ResponseErrorJson("", retorno.MensagemRetorno);

                return ResponseOkJson(retorno, "Produto Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Alterar([FromBody] ProdutoServicoDTO produtoServico)
        {
            try
            {
                var retorno = await _produtoServicoService.Alterar(produtoServico);
                if (!string.IsNullOrEmpty(retorno.MensagemRetorno))
                    return ResponseErrorJson("", retorno.MensagemRetorno);

                return ResponseOkJson(retorno, "Produto Alterado com sucesso!");

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
                var retorno = await _produtoServicoService.Excluir(id);
                if (!string.IsNullOrEmpty(retorno.MensagemRetorno))
                    return ResponseErrorJson("", retorno.MensagemRetorno);

                return ResponseOkJson(retorno, "Produto deletado com sucesso!");

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
                var retorno = await _produtoServicoService.ConsultarPorId(id);

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
                var retorno = await _produtoServicoService.ConsultarProdutos();
               
                return ResponseOkJson(retorno, "Consulta realizada com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
