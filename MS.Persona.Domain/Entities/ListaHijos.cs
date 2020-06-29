using System;
using System.Collections.Generic;

namespace MS.Persona.API.Entities
{
    public partial class ListaHijos
    {
        public int ListaHijosId { get; set; }
        public int PadreDni { get; set; }
        public int? HijoDni { get; set; }
    }
}
