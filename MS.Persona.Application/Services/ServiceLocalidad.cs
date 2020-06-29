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
    public class ServiceLocalidad : IServiceLocalidad
    {
        private readonly IGenericsRepository _repository;
        private readonly ILocalidadQuery _query;
        private readonly IServiceProvincia _serviceProvincia;

        public ServiceLocalidad(IGenericsRepository repository, ILocalidadQuery query, IServiceProvincia serviceProvincia)
        {
            this._repository = repository;
            this._query = query;
            this._serviceProvincia = serviceProvincia;
        }

        public IEnumerable<LocalidadDto> GetLocalidades()
        {
            return _query.GetAllLocalidades();
        }

        public Localidad GetLocalidadByNombreLocalidad(string NombreLocalidad)
        {
            return _query.GetLocalidadByNombreLocalidad(NombreLocalidad);
        }

        public LocalidadDto GetLocalidadDTOByNombreLocalidad(string NombreLocalidad)
        {
            return _query.GetLocalidadDTOByNombreLocalidad(NombreLocalidad);
        }

        public LocalidadDto GetLocalidadDTOByLocalidadId(int LocalidadId)
        {
            return _query.GetLocalidadByLocalidadId(LocalidadId);
        }

        public ResponseLocalidadesPorProvinciaDto GetLocalidadesByNombreProvincia(string NombreProvincia)
        {
            return _query.GetLocalidadesByNombreProvincia(NombreProvincia);
        }

        public RequestProvinciasDto SetLocalidadProvincia(RequestProvinciasDto provincia)
        {
            try
            {
                ProvinciaDto provinciaDto = _serviceProvincia.GetProvinciaDTOByNombreProvincia(provincia.NombreProvincia);
                List<LocalidadDto> localidades = provincia.localidades;
                foreach (LocalidadDto localidad in localidades)
                {
                    if (localidad != null)
                    {
                        var entity = new Localidad
                        {
                            ProvinciaId = provinciaDto.ProvinciaId,
                            NombreLocalidad = localidad.NombreLocalidad
                        };

                        _repository.Add<Localidad>(entity);
                    }
                }
                return provincia;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
