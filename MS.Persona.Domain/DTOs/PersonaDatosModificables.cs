using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Domain.DTOs
{
    public class PersonaDatosModificables
    {
        public int? Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int LocalidadId { get; set; }
        public int GeneroId { get; set; }
        public int EstadoCivilId { get; set; }
    }
}
