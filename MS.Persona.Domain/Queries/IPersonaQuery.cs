using MS.Persona.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Domain.Queries
{
    public interface IPersonaQuery
    {
        List<PersonaDto> GetAllPersonas();
        ResponsePersonaConId GetPersonaByDNI(int Dni);
        PersonaDto GetPersonaByID(int PersonaId);
        int GetPersonaIdByDNI(int Dni);
        int ModifyFechaDefuncion(PersonaDefuncionDto modelDefuncion);
        int ModifyPersona(PersonaDatosModificables modelPersona);

    }
}
