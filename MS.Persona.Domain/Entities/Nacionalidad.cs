using System;
using System.Collections.Generic;

namespace MS.Persona.API.Entities
{
    public partial class Nacionalidad
    {
        public Nacionalidad()
        {
            Persona = new HashSet<Persona>();
        }

        public int NacionalidadId { get; set; }
        public string TipoDeNacionalidad { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}
