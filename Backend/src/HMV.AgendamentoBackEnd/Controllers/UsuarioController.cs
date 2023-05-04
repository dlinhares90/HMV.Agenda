using Microsoft.AspNetCore.Mvc;
using ClinosonBackEnd.Service.Interfaces;
using ClinosonBackEnd.Service.ViewModels;

namespace ClinosonBackEnd.Application.Controllers
{
    /// <summary>
    /// Usuários Controller
    /// </summary>
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : Controller
    {
        #region Fields

        private readonly IUsuarioService _usuarioService;

        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        /// <summary>
        /// Busca o usuário
        /// </summary>
        [Route("{cpf}")]
        [HttpGet]
        [ProducesDefaultResponseType(typeof(UsuarioViewModel))]
        public IActionResult Get(string cpf)
        {
            var response = _usuarioService.Get(cpf);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Inclui o usuário
        /// </summary>
        [Route("")]
        [HttpPost]
        [ProducesDefaultResponseType(typeof(UsuarioViewModel))]
        public IActionResult PostUsuario(PostUsuarioViewModel payload)
        {
            var response = _usuarioService.Post(payload);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Altera o usuário
        /// </summary>
        [Route("{id}")]
        [HttpPut]
        [ProducesDefaultResponseType(typeof(UsuarioViewModel))]
        public IActionResult PutUsuario(int id, PutUsuarioViewModel payload)
        {
            payload.Id = id;
            var response = _usuarioService.Put(payload);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
