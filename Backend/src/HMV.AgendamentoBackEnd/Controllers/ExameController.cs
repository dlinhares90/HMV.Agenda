using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NeurocorBackEnd.Service.Interfaces;
using NeurocorBackEnd.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NeurocorBackEnd.Application.Controllers
{
    /// <summary>
    /// Events Controller
    /// </summary>
    [Route("api/exames")]
    [ApiController]
    public class ExameController : Controller
    {
        #region Fields

        private readonly IExameService _service;

        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        public ExameController(IExameService service)
        {
            _service = service;
        }

        /// <summary>
        /// Busca os exames do usuário
        /// </summary>
        [Route("")]
        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<ExameViewModel>))]
        public IActionResult Get([FromQuery, BindRequired] string cpf)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(e.Message + " " + e.InnerException?.Message);
            }
        }

        /// <summary>
        /// Faz o download do exame do usuário
        /// </summary>
        [Route("{exameId}")]
        [HttpGet]
        [ProducesDefaultResponseType(typeof(bool))]
        public IActionResult GetExame(int exameId)
        {
            try
            {
                var exame = _service.GetExame(exameId);

                if (exame.Length > 0)
                {
                    return File(exame, "application/octet-stream", $"Exame-{exameId}.pdf");
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
