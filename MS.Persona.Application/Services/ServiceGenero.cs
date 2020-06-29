using MS.Persona.API.Entities;
using MS.Persona.Domain.Commands;
using MS.Persona.Domain.DTOs;
using MS.Persona.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class ServiceGenero : IServiceGenero
    {
        private readonly IGenericsRepository _repository;
        private readonly IGeneroQuery _query;

        public ServiceGenero(IGenericsRepository repository, IGeneroQuery query)
        {
            this._repository = repository;
            this._query = query;
        }

        public IEnumerable<ResponseGeneros> GetGeneros()
        {
            return _query.GetAllGeneros();
        }

        public GeneroDto GetGenerobyTipoGenero(string TipoGenero)
        {
            return _query.GetGeneroDTOByTipoGenero(TipoGenero);
        }

        public ResponseGeneros GetGeneroByGeneroId(int? GeneroId)
        {
            return _query.GetGeneroByGeneroId(GeneroId);
        }

        public ResponseGeneros SetGenero(GeneroDto genero)
        {
            ResponseGeneros responseGeneros = new ResponseGeneros();

            var entity = new Genero
            {
                TipoGenero = genero.TipoGenero
            };

            _repository.Add<Genero>(entity);
            responseGeneros.TipoGenero = entity.TipoGenero;
            return responseGeneros;
        }

        public ResponseGeneros GetGeneroByTipoGenero(string TipoGenero)
        {
            return _query.GetGeneroByTipoGenero(TipoGenero);
        }
    }
}
