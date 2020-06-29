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
    public class ProvinciaQuery : IProvinciaQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _sqlKataCompiler;

        public ProvinciaQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this._connection = connection;
            this._sqlKataCompiler = sqlKataCompiler;
        }

        public List<ProvinciaDto> GetAllProvincias()
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var query = db.Query("Provincia"); //select all

            var result = query.Get<ProvinciaDto>();

            return result.ToList();
        }

        public ProvinciaDto GetProvinciasDTOByNombreProvincia(string NombreProvincia)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var provincia = db.Query("Provincia")
                .Select("Provincia.ProvinciaId", "Provincia.NombreProvincia")
                .Where("NombreProvincia", "=", NombreProvincia)
                .FirstOrDefault<ProvinciaDto>();


            return new ProvinciaDto
            {
                ProvinciaId = provincia.ProvinciaId,
                NombreProvincia = provincia.NombreProvincia
            };
        }

        public Provincia GetProvinciaByNombreProvincia(string NombreProvincia)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var provincia = db.Query("Provincia")
                .Select("Provincia.ProvinciaId", "Provincia.NombreProvincia")
                .Where("NombreProvincia", "=", NombreProvincia)
                .FirstOrDefault<Provincia>();

            return provincia;

        }

        public ProvinciaDto GetProvinciaDTOByProvinciaId(int ProvinciaId)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var provincia = db.Query("Provincia")
                .Select("Provincia.ProvinciaId", "Provincia.NombreProvincia")
                .Where("ProvinciaId", "=", ProvinciaId)
                .FirstOrDefault<ProvinciaDto>();

            return provincia;
        }

    }
}
