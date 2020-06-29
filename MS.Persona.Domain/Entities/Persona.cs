using System;
using System.Collections.Generic;

namespace MS.Persona.API.Entities
{
    public partial class Persona
    {
        public int PersonaId { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? GeneroId { get; set; }
        public int EstadoCivilId { get; set; }
        public int NacionalidadId { get; set; }
        public int LocalidadId { get; set; }
        public string Direccion { get; set; }
        public bool TieneHijos { get; set; }
        public DateTime? FechaDefuncion { get; set; }

        public virtual EstadoCivil EstadoCivil { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Localidad Localidad { get; set; }
        public virtual Nacionalidad Nacionalidad { get; set; }
    }
}
