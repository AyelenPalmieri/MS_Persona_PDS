using MS.Persona.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IServiceGenero
    {
        ResponseGeneros SetGenero(GeneroDto genero);
        IEnumerable<ResponseGeneros> GetGeneros();
        GeneroDto GetGenerobyTipoGenero(string TipoGenero);
        ResponseGeneros GetGeneroByTipoGenero(string TipoGenero);
        ResponseGeneros GetGeneroByGeneroId(int? GeneroId);
    }
}
