using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Domain.DTOs
{
    public class ResponsePersonaConId
    {
        public int PersonaId { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int GeneroId { get; set; }
        public int EstadoCivilId { get; set; }
        public int NacionalidadId { get; set; }
        public int ProvinciaId { get; set; }
        public int LocalidadId { get; set; }
        public string Direccion { get; set; }
        public bool TieneHijos { get; set; }
        public DateTime? FechaDefuncion { get; set; }

        public ResponseNacionalidad Nacionalidad { get; set; }
        public EstadoCivilDto EstadoCivil { get; set; }
        public ResponseGeneros Genero { get; set; }
        public ProvinciaDto Provincia { get; set; }
        public LocalidadDto Localidad { get; set; }

    }
}
