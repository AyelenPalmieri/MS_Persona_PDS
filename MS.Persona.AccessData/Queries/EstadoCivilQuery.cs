using MS.Persona.API.Entities;
using MS.Persona.Domain.DTOs;
using MS.Persona.Domain.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MS.Persona.AccessData.Queries
{
    public class EstadoCivilQuery : IEstadoCivilQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _sqlKataCompiler;

        public EstadoCivilQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this._connection = connection;
            this._sqlKataCompiler = sqlKataCompiler;
        }

        public List<EstadoCivilDto> GetAllEstadosCiviles()
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var query = db.Query("EstadoCivil"); //select all

            var result = query.Get<EstadoCivilDto>();

            return result.ToList();
        }

        public EstadoCivilDto GetEstadoCivilDTOByTipoEstadoCivil(string TipoEstadoCivil)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var estadoCivil = db.Query("EstadoCivil")
                .Select("EstadoCivil.EstadoCivilId", "EstadoCivil.TipoEstadoCivil")
                .Where("TipoEstadoCivil", "=", TipoEstadoCivil)
                .FirstOrDefault<EstadoCivilDto>();


            return new EstadoCivilDto
            {
                EstadoCivilId = estadoCivil.EstadoCivilId,
                TipoEstadoCivil = estadoCivil.TipoEstadoCivil
            };

        }

        public EstadoCivilDto GetEstadoCivilDTOByEstadoCivilId(int EstadoCivilId)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var estadoCivil = db.Query("EstadoCivil")
                .Select("EstadoCivil.EstadoCivilId", "EstadoCivil.TipoEstadoCivil")
                .Where("EstadoCivilId", "=", EstadoCivilId)
                .FirstOrDefault<EstadoCivilDto>();


            return new EstadoCivilDto
            {
                EstadoCivilId = estadoCivil.EstadoCivilId,
                TipoEstadoCivil = estadoCivil.TipoEstadoCivil
            };

        }

        public EstadoCivil GetEstadoCivilByTipoEstadoCivil(string TipoEstadoCivil)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var estadoCivil = db.Query("EstadoCivil")
                .Select("EstadoCivil.EstadoCivilId", "EstadoCivil.TipoEstadoCivil")
                .Where("TipoEstadoCivil", "=", TipoEstadoCivil)
                .FirstOrDefault<EstadoCivil>();

            return estadoCivil;

        }
    }
}
