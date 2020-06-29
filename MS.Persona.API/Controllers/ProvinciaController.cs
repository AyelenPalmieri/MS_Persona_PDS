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
    public class ProvinciaController : ControllerBase
    {
        private readonly IServiceLocalidad _service;
        private readonly IServiceProvincia _serviceProvincia;

        public ProvinciaController(IServiceLocalidad service, IServiceProvincia serviceProvincia)
        {
            this._service = service;
            this._serviceProvincia = serviceProvincia;
        }

        //NO TOCAR
        //[GET /api/provincia/AllProvincias]
        [HttpGet("AllProvincias")]
        public IActionResult AllProvincias()
        {
            try
            {
                var provincias = _serviceProvincia.GetProvincias();
                return new JsonResult(provincias) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

        //NO TOCAR
        //[POST /api/provincia/SetProvincia]
        [HttpPost("SetProvincia")]
        public IActionResult SetProvincia([FromBody] RequestProvinciaSetProvinciaDto provincia)
        {
            try
            {
                ResponseProvincia aProvincia = _serviceProvincia.SetProvincia(provincia);
                aProvincia.ProvinciaId = _serviceProvincia.GetProvinciaByNombreProvincia(aProvincia.NombreProvincia).ProvinciaId;
                return new JsonResult(aProvincia) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

        }

        //NO TOCAR
        //[GET /api/provincia/GetLocalidadesByProvincia]
        [HttpGet("GetLocalidadesByProvincia/{NombreProvincia}")]
        public IActionResult GetLocalidadesByProvincia(string NombreProvincia)
        {
            try
            {
                var localidades = _service.GetLocalidadesByNombreProvincia(NombreProvincia);
                return new JsonResult(localidades) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

        //NO TOCAR
        //[POST /api/provincia/SetLocalidadesByNombreProvincia]
        [HttpPost("SetLocalidadesByNombreProvincia")]
        public IActionResult SetLocalidadesByNombreProvincia([FromBody] RequestProvinciasDto localidadesPorProvincia)
        {
            try
            {
                var provincia = _service.SetLocalidadProvincia(localidadesPorProvincia);
                var localidades = _service.GetLocalidadesByNombreProvincia(provincia.NombreProvincia);
                return new JsonResult(localidades) { StatusCode = 201 }; ;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}