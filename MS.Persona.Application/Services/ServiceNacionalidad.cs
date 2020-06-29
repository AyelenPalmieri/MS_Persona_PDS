using MS.Persona.API.Entities;
using MS.Persona.Domain.Commands;
using MS.Persona.Domain.DTOs;
using MS.Persona.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Application.Services
{
    public class ServiceNacionalidad : IServiceNacionalidad
    {
        private readonly IGenericsRepository _repository;
        private readonly INacionalidadQuery _query;

        public ServiceNacionalidad(IGenericsRepository repository, INacionalidadQuery query)
        {
            this._repository = repository;
            this._query = query;
        }

        public NacionalidadDto GetNacionalidadDTOByTipoDeNacionalidad(string TipoDeNacionalidad)
        {
            return _query.GetNacionalidadDTOByTipoNacionalidad(TipoDeNacionalidad);
        }

        public ResponseNacionalidad GetNacionalidadByNacionalidadId(int NacionalidadId)
        {
            return _query.GetNacionalidadByNacionalidadId(NacionalidadId);
        }

        public IEnumerable<ResponseNacionalidad> GetNacionalidades()
        {
            return _query.GetAllNacionalidades();
        }

        public ResponseNacionalidad SetNacionalidad(NacionalidadDto nacionalidad)
        {
            ResponseNacionalidad responseNacionalidad = new ResponseNacionalidad();

            var entity = new Nacionalidad
            {
                TipoDeNacionalidad = nacionalidad.TipoDeNacionalidad
            };

            _repository.Add<Nacionalidad>(entity);
            responseNacionalidad.TipoDeNacionalidad = entity.TipoDeNacionalidad;
            return responseNacionalidad;
        }

        public ResponseNacionalidad GetNacionalidadByTipoNacionalidad(string TipoDeNacionalidad)
        {
            return _query.GetNacionalidadByTipoNacionalidad(TipoDeNacionalidad);
        }
    }
}
