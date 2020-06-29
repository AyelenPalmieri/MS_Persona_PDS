using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Domain.DTOs
{
    public class ResponseLocalidadesPorProvinciaDto
    {
        public int ProvinciaId { get; set; }
        public string NombreProvincia { get; set; }
        public List<LocalidadDto> Localidades { get; set; }
    }
}
