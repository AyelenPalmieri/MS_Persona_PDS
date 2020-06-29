using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using MS.Persona.Domain.DTOs;
using MS.Persona.Domain.Commands;
using MS.Persona.Domain.Queries;
using MS.Persona.API.Entities;

namespace Services
{
    public class ServiceProvincia : IServiceProvincia
    {
        private readonly IGenericsRepository _repository;
        private readonly IProvinciaQuery _query;

        public ServiceProvincia(IGenericsRepository repository, IProvinciaQuery query)
        {
            this._repository = repository;
            this._query = query;
        }

        public IEnumerable<ProvinciaDto> GetProvincias()
        {
            return _query.GetAllProvincias();
        }

        public ProvinciaDto GetProvinciaDTOByNombreProvincia(string NombreProvincia)
        {
            return _query.GetProvinciasDTOByNombreProvincia(NombreProvincia);
        }

        public Provincia GetProvinciaByNombreProvincia(string NombreProvincia)
        {
            return _query.GetProvinciaByNombreProvincia(NombreProvincia);
        }

        public ProvinciaDto GetProvinciaDTOByProvinciaId(int ProvinciaId)
        {
            return _query.GetProvinciaDTOByProvinciaId(ProvinciaId);
        }

        public ResponseProvincia SetProvincia(RequestProvinciaSetProvinciaDto provincia)
        {
            ResponseProvincia responseProvincia = new ResponseProvincia();

            var entity = new Provincia
            {
                NombreProvincia = provincia.NombreProvincia
            };

            _repository.Add<Provincia>(entity);
            responseProvincia.NombreProvincia = entity.NombreProvincia;
            return responseProvincia;
        }

    }
}
