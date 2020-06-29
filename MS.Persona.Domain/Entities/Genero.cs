using System;
using System.Collections.Generic;

namespace MS.Persona.API.Entities
{
    public partial class Genero
    {
        public Genero()
        {
            Persona = new HashSet<Persona>();
        }

        public int GeneroId { get; set; }
        public string TipoGenero { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}
