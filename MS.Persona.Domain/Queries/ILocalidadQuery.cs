using MS.Persona.API.Entities;
using MS.Persona.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Domain.Queries
{
    public interface ILocalidadQuery
    {
        List<LocalidadDto> GetAllLocalidades();
        LocalidadDto GetLocalidadDTOByNombreLocalidad(string NombreLocalidad);
        Localidad GetLocalidadByNombreLocalidad(string NombreLocalidad);
        ResponseLocalidadesPorProvinciaDto GetLocalidadesByNombreProvincia(string NombreProvincia);
        LocalidadDto GetLocalidadByLocalidadId(int LocalidadId);
    }
}
