using MS.Persona.API.Entities;
using MS.Persona.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IServiceEstadoCivil
    {
        EstadoCivilDto SetEstadoCivil(EstadoCivilDto estadoCivil);
        IEnumerable<EstadoCivilDto> GetEstadosCiviles();
        EstadoCivilDto GetEstadoCivilDTOByTipoEstadoCivil(string TipoEstadoCivil);
        EstadoCivil GetEstadoCivilByTipoEstadoCivil(string TipoEstadoCivil);
        EstadoCivilDto GetEstadoCivilDTOByEstadoCivilId(int EstadoCivilId);
    }
}
