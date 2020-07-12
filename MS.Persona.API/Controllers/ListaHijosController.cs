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
    public class ListaHijosController : ControllerBase
    {
        private readonly IServiceListaHijos _service;

        public ListaHijosController(IServiceListaHijos service)
        {
            this._service = service;
        }

        //GET /api/listahijos/GetHijosByPadreDni{PadreDni}
        [HttpGet("GetHijosByPadreDni/{PadreDni}")]
        public IActionResult GetHijosByPadreDni(int PadreDni)
        {
            try
            {
                ResponseListaHijosDto listaHijos = _service.GetHijosByPadreDni(PadreDni);
                return new JsonResult(listaHijos) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

        //POST /api/listahijos/SetHijos
        [HttpPost("SetHijos")]
        public IActionResult SetHijos([FromBody] RequestListaHijosDto requestlistaHijos)
        {
            try
            {
                bool padreExist = _service.PersonaExist(requestlistaHijos.PadreDni);
                bool hijoExist = _service.PersonaExist(requestlistaHijos.HijoDni);

                if (padreExist == true && hijoExist == true)
                {
                    if (requestlistaHijos.HijoDni != requestlistaHijos.PadreDni)
                    {
                        ResponseListaHijosDto listaHijos = _service.SetHijos(requestlistaHijos);
                        return new JsonResult(listaHijos) { StatusCode = 201 };
                    }
                    return StatusCode((int)HttpStatusCode.BadRequest);
                }
                else {
                    return StatusCode((int)HttpStatusCode.BadRequest);
                }
            } catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }
    }      
}