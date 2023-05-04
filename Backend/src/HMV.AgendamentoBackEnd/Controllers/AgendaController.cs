using HMV.AgendamentoBackEnd.Service.Interfaces;
using HMV.AgendamentoBackEnd.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;

namespace HMV.AgendamentoBackEnd.Application.Controllers
{
    /// <summary>
    /// Events Controller
    /// </summary>
    [Route("api/agendas")]
    [ApiController]
    public class AgendaController : Controller
    {
        #region Fields

        private readonly IAgendaService _service;

        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        public AgendaController(IAgendaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Busca as agendas
        /// </summary>
        [Route("")]
        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<AgendaViewModel>))]
        public IActionResult Get([FromQuery, BindRequired] int idItem, [FromQuery, BindRequired] int idConvenio, [FromQuery, BindRequired] int idPrestador)
        {
            try
            {
                var response = _service.GetAgendas(idItem, idConvenio, idPrestador);

                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " " + e.InnerException?.Message);
            }
        }
    }
}
