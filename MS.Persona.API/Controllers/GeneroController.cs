using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS.Persona.Domain.DTOs;
using Services;

namespace MS.Persona.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IServiceGenero _service;

        public GeneroController(IServiceGenero service)
        {
            this._service = service;
        }

        //[POST /api/genero/SetGenero]
        [HttpPost("SetGenero")]
        public IActionResult SetGenero([FromBody] GeneroDto genero)
        {
            try
            {
                ResponseGeneros aGenero = _service.SetGenero(genero);
                aGenero.GeneroId = _service.GetGeneroByTipoGenero(aGenero.TipoGenero).GeneroId;
                return new JsonResult(aGenero) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

        }

        //[GET /api/genero/AllGeneros]
        [HttpGet("AllGeneros")]
        public IActionResult AllGeneros()
        {
            try
            {
                var generos = _service.GetGeneros();
                return new JsonResult(generos) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }


    }
}