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
    public class ServiceEstadoCivil : IServiceEstadoCivil
    {
        private readonly IGenericsRepository _repository;
        private readonly IEstadoCivilQuery _query;

        public ServiceEstadoCivil(IGenericsRepository repository, IEstadoCivilQuery query)
        {
            this._repository = repository;
            this._query = query;
        }

        public IEnumerable<EstadoCivilDto> GetEstadosCiviles()
        {
            return _query.GetAllEstadosCiviles();
        }

        public EstadoCivilDto GetEstadoCivilDTOByTipoEstadoCivil(string TipoEstadoCivil)
        {
            return _query.GetEstadoCivilDTOByTipoEstadoCivil(TipoEstadoCivil);
        }

        public EstadoCivilDto GetEstadoCivilDTOByEstadoCivilId(int EstadoCivilId)
        {
            return _query.GetEstadoCivilDTOByEstadoCivilId(EstadoCivilId);
        }

        public EstadoCivilDto SetEstadoCivil(EstadoCivilDto estadoCivil)
        {
            var entity = new EstadoCivil
            {
                EstadoCivilId = estadoCivil.EstadoCivilId,
                TipoEstadoCivil = estadoCivil.TipoEstadoCivil
            };

            _repository.Add<EstadoCivil>(entity);
            return estadoCivil;
        }

        public EstadoCivil GetEstadoCivilByTipoEstadoCivil(string TipoEstadoCivil)
        {
            return _query.GetEstadoCivilByTipoEstadoCivil(TipoEstadoCivil);
        }

    }
}
