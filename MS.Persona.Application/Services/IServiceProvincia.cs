using MS.Persona.API.Entities;
using MS.Persona.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IServiceProvincia
    {
        ResponseProvincia SetProvincia(RequestProvinciaSetProvinciaDto provincia);
        IEnumerable<ProvinciaDto> GetProvincias();
        ProvinciaDto GetProvinciaDTOByNombreProvincia(string NombreProvincia);
        Provincia GetProvinciaByNombreProvincia(string NombreProvincia);
        ProvinciaDto GetProvinciaDTOByProvinciaId(int ProvinciaId);
    }
}
