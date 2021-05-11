using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRIA.Portal.API.Base;
using TRIA.Portal.Domain.DTO;
using TRIA.Portal.Domain.DTO.Auth;
using TRIA.Portal.Domain.Interfaces.Services;

namespace TRIA.Portal.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public AccountController(IUserService userService,
            ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            try
            {
                var usuario = await _userService.ConsultarUsuario(login);
                if (!string.IsNullOrEmpty(usuario.MensagemRetorno))
                    return ResponseErrorJson("", usuario.MensagemRetorno);

                var tokenModel = _tokenService.GerarToken(usuario);

                return ResponseOkJson(tokenModel, "Autenticado com Sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastroUsuario([FromBody] UserDTO user)
        {
            try
            {
                var retorno = await _userService.CadastrarUsuario(user);
                if (!string.IsNullOrEmpty(retorno.MensagemRetorno))
                    return ResponseErrorJson("", retorno.MensagemRetorno);

                return ResponseOkJson(retorno, "Usuario Cadastrado com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
