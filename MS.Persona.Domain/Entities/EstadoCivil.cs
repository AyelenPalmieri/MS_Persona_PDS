using System;
using System.Collections.Generic;

namespace MS.Persona.API.Entities
{
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            Persona = new HashSet<Persona>();
        }

        public int EstadoCivilId { get; set; }
        public string TipoEstadoCivil { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}
