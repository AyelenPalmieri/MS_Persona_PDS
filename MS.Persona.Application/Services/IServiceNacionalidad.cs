using MS.Persona.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Application.Services
{
    public interface IServiceNacionalidad
    {
        ResponseNacionalidad SetNacionalidad(NacionalidadDto nacionalidad);
        IEnumerable<ResponseNacionalidad> GetNacionalidades();
        NacionalidadDto GetNacionalidadDTOByTipoDeNacionalidad(string TipoDeNacionalidad);
        ResponseNacionalidad GetNacionalidadByTipoNacionalidad(string TipoDeNacionalidad);
        ResponseNacionalidad GetNacionalidadByNacionalidadId(int NacionalidadId);

    }
}
