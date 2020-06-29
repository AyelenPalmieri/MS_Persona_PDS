using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Domain.DTOs
{
    public class RequestProvinciasDto
    {
        public string NombreProvincia { get; set; }
        public List<LocalidadDto> localidades { get; set; }
    }
}
