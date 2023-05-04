using Microsoft.AspNetCore.Mvc;
using ClinosonBackEnd.Service.Interfaces;
using ClinosonBackEnd.Service.ViewModels;

namespace ClinosonBackEnd.Application.Controllers
{
    /// <summary>
    /// Pacientes Controller
    /// </summary>
    [Route("api/pacientes")]
    [ApiController]
    public class PacienteController : Controller
    {
        #region Fields

        private readonly IPacienteService _service;

        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        public PacienteController(IPacienteService service)
        {
            _service = service;
        }


        /// <summary>
        /// Busca o paciente por cpf
        /// </summary>
        [Route("{cpf}")]
        [HttpGet]
        [ProducesDefaultResponseType(typeof(PacienteViewModel))]
        public IActionResult Get(string cpf)
        {
            var response = _service.Get(cpf);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }
    }
}