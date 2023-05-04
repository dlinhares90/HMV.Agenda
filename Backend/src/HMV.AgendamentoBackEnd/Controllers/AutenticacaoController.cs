using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ClinosonBackEnd.Service.Interfaces;
using ClinosonBackEnd.Service.ViewModels;
using System;

namespace ClinosonBackEnd.Application.Controllers
{
    /// <summary>
    /// Autenticação Controller
    /// </summary>
    [Route("api/autenticacao")]
    [AllowAnonymous]
    [ApiController]
    public class AutenticacaoController : Controller
    {
        #region Fields

        private readonly IAutenticacaoService _autenticacaoService;

        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        public AutenticacaoController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        /// <summary>
        /// Autentica um usuário
        /// </summary>
        [Route("")]
        [HttpPost]
        [ProducesDefaultResponseType(typeof(bool))]
        public IActionResult Post(PostAutenticacaoViewModel payload)
        {
            try
            {
                var response = _autenticacaoService.Post(payload);

                if (response)
                {
                    return Ok(response);
                }
                else
                {
                    return Unauthorized("Usuário ou senha inválidos.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " " + e.InnerException?.Message);
            }
        }
    }
}
