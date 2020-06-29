using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Domain.DTOs
{
    public class ResponseListaHijosDto
    {
        public int PadreDni { get; set; }
        public List<HijoDto> Hijos { get; set; }
    }
}
