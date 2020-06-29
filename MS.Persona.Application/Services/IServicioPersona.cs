using MS.Persona.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IServicioPersona
    {
        ResponsePersonaConId SetPersona(PersonaDto persona);
        PersonaDto GetPersonaByID(int PersonaId);
        ResponsePersonaConId GetPersonaByDNI(int Dni);
        IEnumerable<PersonaDto> GetPersonas();
        int ModifyFechaDefuncion(PersonaDefuncionDto modelDefuncion);
        int ModifyPersona(PersonaDatosModificablesString modelPersona);
        bool IsValid(PersonaDatosModificablesString personaDatosModificablesString);
    }
}
