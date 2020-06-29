using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS.Persona.Application.Services;
using MS.Persona.Domain.DTOs;

namespace MS.Persona.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NacionalidadController : ControllerBase
    {
        private readonly IServiceNacionalidad _service;

        public NacionalidadController(IServiceNacionalidad service)
        {
            this._service = service;

        }

        //NO TOCAR
        //[GET /api/nacionalidad/AllNacionalidades]
        [HttpGet("AllNacionalidades")]
        public IActionResult AllNacionalidades()
        {
            try
            {
                var nacionalidades = _service.GetNacionalidades();
                return new JsonResult(nacionalidades) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

        //NO TOCAR
        //[POST /api/nacionalidad/SetNacionalidad]
        [HttpPost("SetNacionalidad")]
        public IActionResult SetNacionalidad([FromBody] NacionalidadDto nacionalidad)
        {
            try
            {
                ResponseNacionalidad aNacionalidad = _service.SetNacionalidad(nacionalidad);
                aNacionalidad.NacionalidadId = _service.GetNacionalidadByTipoNacionalidad(aNacionalidad.TipoDeNacionalidad).NacionalidadId;
                return new JsonResult(aNacionalidad) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

        }
    }
}