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
    public class PersonaController : ControllerBase
    {
        private readonly IServicioPersona _service;
        private readonly IServiceLocalidad _serviceLocalidad;
        private readonly IServiceGenero _serviceGenero;
        private readonly IServiceEstadoCivil _serviceEstadoCivil;

        public PersonaController(IServicioPersona service, IServiceLocalidad serviceLocalidad, IServiceGenero serviceGenero, IServiceEstadoCivil serviceEstadoCivil)
        {
            this._service = service;
            this._serviceLocalidad = serviceLocalidad;
            this._serviceGenero = serviceGenero;
            this._serviceEstadoCivil = serviceEstadoCivil;
        }

        //[GET /api/persona/AllPersonas]
        [HttpGet("AllPersonas")]
        public IActionResult AllPersonas() //PROBLEMA CON EL MODELO, NO TRAE STRING DE DATOS
        {
            try
            {
                var personas = _service.GetPersonas();
                return new JsonResult(personas) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

        [HttpPut("ModifyFechaDefuncion")]
        public IActionResult ModifyFechaDefuncion([FromBody] PersonaDefuncionDto modelDefuncion)
        {
            try
            {
                int affected = _service.ModifyFechaDefuncion(modelDefuncion);
                return new JsonResult(affected) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

        [HttpPut("ModifyPersona")]
        public IActionResult ModifyPersona([FromBody] PersonaDatosModificablesString modelPersona)
        {
            try
            {
                bool condicion = _service.IsValid(modelPersona);
                if (condicion == true)
                {
                    int affected = _service.ModifyPersona(modelPersona);
                    return new JsonResult(affected) { StatusCode = 200 };
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest);
                }
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

        //[POST /api/persona/SetPersona]
        [HttpPost("SetPersona")]
        public IActionResult SetPersona([FromBody] PersonaDto persona)
        {
            try
            {
                ResponsePersonaConId apersona = _service.SetPersona(persona);
                return new JsonResult(apersona) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

        }

        //GET /api/persona/GetPersona{Dni}
        [HttpGet("GetPersona/{Dni}")]
        public IActionResult GetPersona(int Dni)
        {
            try
            {
                var persona = _service.GetPersonaByDNI(Dni);
                return new JsonResult(persona) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }
    }
}