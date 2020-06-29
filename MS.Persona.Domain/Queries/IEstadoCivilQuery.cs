using MS.Persona.API.Entities;
using MS.Persona.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Domain.Queries
{
    public interface IEstadoCivilQuery
    {
        List<EstadoCivilDto> GetAllEstadosCiviles();
        EstadoCivilDto GetEstadoCivilDTOByTipoEstadoCivil(string TipoEstadoCivil);
        EstadoCivil GetEstadoCivilByTipoEstadoCivil(string TipoEstadoCivil);
        EstadoCivilDto GetEstadoCivilDTOByEstadoCivilId(int EstadoCivilId);
    }
}
