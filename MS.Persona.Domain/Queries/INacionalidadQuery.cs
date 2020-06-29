using MS.Persona.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Domain.Queries
{
    public interface INacionalidadQuery
    {
        List<ResponseNacionalidad> GetAllNacionalidades();
        NacionalidadDto GetNacionalidadDTOByTipoNacionalidad(string TipoDeNacionalidad);
        ResponseNacionalidad GetNacionalidadByTipoNacionalidad(string TipoDeNacionalidad);
        ResponseNacionalidad GetNacionalidadByNacionalidadId(int NacionalidadId);
    }
}
