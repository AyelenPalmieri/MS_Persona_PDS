using MS.Persona.API.Entities;
using MS.Persona.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Domain.Queries
{
    public interface IProvinciaQuery
    {
        List<ProvinciaDto> GetAllProvincias();
        ProvinciaDto GetProvinciasDTOByNombreProvincia(string NombreProvincia);
        Provincia GetProvinciaByNombreProvincia(string NombreProvincia);
        ProvinciaDto GetProvinciaDTOByProvinciaId(int ProvinciaId);
    }
}
