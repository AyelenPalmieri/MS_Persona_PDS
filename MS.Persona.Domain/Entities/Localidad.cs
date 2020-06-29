using System;
using System.Collections.Generic;

namespace MS.Persona.API.Entities
{
    public partial class Localidad
    {
        public Localidad()
        {
            Persona = new HashSet<Persona>();
        }

        public int LocalidadId { get; set; }
        public int ProvinciaId { get; set; }
        public string NombreLocalidad { get; set; }

        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
