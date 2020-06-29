using System;
using System.Collections.Generic;

namespace MS.Persona.API.Entities
{
    public partial class Provincia
    {
        public Provincia()
        {
            Localidad = new HashSet<Localidad>();
        }

        public int ProvinciaId { get; set; }
        public string NombreProvincia { get; set; }

        public virtual ICollection<Localidad> Localidad { get; set; }
    }
}
