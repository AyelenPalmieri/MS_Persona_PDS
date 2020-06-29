using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Domain.DTOs
{
    public class ResponsePersona
    {
        public int PersonaId { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public string Nacionalidad { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Direccion { get; set; }
        public bool TieneHijos { get; set; }
        public DateTime? FechaDefuncion { get; set; }
    }
}
