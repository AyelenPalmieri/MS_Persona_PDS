using MS.Persona.API.Entities;
using MS.Persona.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IServiceLocalidad
    {
        IEnumerable<LocalidadDto> GetLocalidades();
        LocalidadDto GetLocalidadDTOByNombreLocalidad(string NombreLocalidad);
        Localidad GetLocalidadByNombreLocalidad(string NombreLocalidad);
        RequestProvinciasDto SetLocalidadProvincia(RequestProvinciasDto provincia);
        ResponseLocalidadesPorProvinciaDto GetLocalidadesByNombreProvincia(string NombreProvincia);
        LocalidadDto GetLocalidadDTOByLocalidadId(int LocalidadId);
    }
}
