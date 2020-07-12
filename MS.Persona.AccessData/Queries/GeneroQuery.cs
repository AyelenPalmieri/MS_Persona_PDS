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
    public class GeneroQuery : IGeneroQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _sqlKataCompiler;

        public GeneroQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this._connection = connection;
            this._sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseGeneros> GetAllGeneros()
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var query = db.Query("Genero"); //select all

            var result = query.Get<ResponseGeneros>();

            return result.ToList();
        }

        public GeneroDto GetGeneroDTOByTipoGenero(string TipoGenero)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var genero = db.Query("Genero")
                .Select("Genero.GeneroId", "Genero.TipoGenero")
                .Where("TipoGenero", "=", TipoGenero)
                .FirstOrDefault<GeneroDto>();


            return new GeneroDto
            {
                TipoGenero = genero.TipoGenero
            };
        }

        public ResponseGeneros GetGeneroByGeneroId(int? GeneroId)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var genero = db.Query("Genero")
                .Select("Genero.GeneroId", "Genero.TipoGenero")
                .Where("GeneroId", "=", GeneroId)
                .FirstOrDefault<ResponseGeneros>();

            return genero;
        }

        public ResponseGeneros GetGeneroByTipoGenero(string TipoGenero)
        {
            try
            {
                var db = new QueryFactory(_connection, _sqlKataCompiler);

                var genero = db.Query("Genero")
                    .Select("Genero.GeneroId", "Genero.TipoGenero")
                    .Where("TipoGenero", "=", TipoGenero)
                    .FirstOrDefault<ResponseGeneros>();

                if (genero == null) {
                    throw new ArgumentNullException();
                }

                return genero;
            }
            catch (Exception e) {
                throw e;
            }

        }

    }
}
