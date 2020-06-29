using MS.Persona.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Domain.Queries
{
    public interface IGeneroQuery
    {
        List<ResponseGeneros> GetAllGeneros();
        GeneroDto GetGeneroDTOByTipoGenero(string TipoGenero);
        ResponseGeneros GetGeneroByTipoGenero(string TipoGenero);
        ResponseGeneros GetGeneroByGeneroId(int? GeneroId);
    }
}
