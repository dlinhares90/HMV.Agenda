using HMV.AgendamentoBackEnd.Service.Interfaces;
using HMV.AgendamentoBackEnd.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HMV.AgendamentoBackEnd.Application.Controllers
{
    /// <summary>
    /// Lista de Valores Controller
    /// </summary>
    [Route("api/lov")]
    [ApiController]
    public class LovController : Controller
    {
        #region Fields

        private readonly ILovService _service;

        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        public LovController(ILovService service)
        {
            _service = service;
        }

        /// <summary>
        /// Busca a lista de itens
        /// </summary>
        [Route("itens")]
        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<LovItemViewModel>))]
        public IActionResult GetItens()
        {
            try
            {
                var response = _service.GetItens();

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

        /// <summary>
        /// Busca a lista de convênios
        /// </summary>
        [Route("convenios")]
        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<LovConvenioViewModel>))]
        public IActionResult GetConvenios(int idItem)
        {
            try
            {
                var response = _service.GetConvenios(idItem);

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

        /// <summary>
        /// Busca a lista de prestadores
        /// </summary>
        [Route("prestadores")]
        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<LovPrestadoreViewModel>))]
        public IActionResult GetPrestadores(int idItem, int idConvenio)
        {
            try
            {
                var response = _service.GetPrestadores(idItem, idConvenio);

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
