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
    public class EstadoCivilController : ControllerBase
    {
        private readonly IServiceEstadoCivil _service;

        public EstadoCivilController(IServiceEstadoCivil service)
        {
            this._service = service;
        }

        //[GET /api/estadocivil/AllEstadosCiviles]
        [HttpGet("AllEstadosCiviles")]
        public IActionResult AllEstadosCiviles()
        {
            try
            {
                var estadosCiviles = _service.GetEstadosCiviles();
                return new JsonResult(estadosCiviles) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

    }
}
