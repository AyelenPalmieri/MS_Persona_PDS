using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MS.Persona.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : ControllerBase
    {
        private readonly IServiceLocalidad _service;

        public LocalidadController(IServiceLocalidad service)
        {
            this._service = service;
        }

        //[GET /api/localidad/AllLocalidades]
        [HttpGet("AllLocalidades")]
        public IActionResult AllLocalidades()
        {
            try
            {
                var localidades = _service.GetLocalidades();
                return new JsonResult(localidades) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }
    }
}