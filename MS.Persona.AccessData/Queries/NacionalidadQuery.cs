using MS.Persona.Domain.DTOs;
using MS.Persona.Domain.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MS.Persona.AccessData.Queries
{
    public class NacionalidadQuery : INacionalidadQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _sqlKataCompiler;

        public NacionalidadQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this._connection = connection;
            this._sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseNacionalidad> GetAllNacionalidades()
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var query = db.Query("Nacionalidad"); //select all

            var result = query.Get<ResponseNacionalidad>();

            return result.ToList();
        }


        public NacionalidadDto GetNacionalidadDTOByTipoNacionalidad(string TipoDeNacionalidad)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var nacionalidad = db.Query("Nacionalidad")
                .Select("Nacionalidad.NacionalidadId", "Nacionalidad.TipoDeNacionalidad")
                .Where("TipoDeNacionalidad", "=", TipoDeNacionalidad)
                .FirstOrDefault<NacionalidadDto>();


            return new NacionalidadDto
            {
                TipoDeNacionalidad = nacionalidad.TipoDeNacionalidad
            };
        }

        public ResponseNacionalidad GetNacionalidadByNacionalidadId(int NacionalidadId)
        {
            try
            {
                var db = new QueryFactory(_connection, _sqlKataCompiler);

                var nacionalidad = db.Query("Nacionalidad")
                    .Select("Nacionalidad.NacionalidadId", "Nacionalidad.TipoDeNacionalidad")
                    .Where("NacionalidadId", "=", NacionalidadId)
                    .FirstOrDefault<ResponseNacionalidad>();

                if (nacionalidad == null) {
                    return new ResponseNacionalidad();
                }

                return new ResponseNacionalidad
                {
                    NacionalidadId = nacionalidad.NacionalidadId,
                    TipoDeNacionalidad = nacionalidad.TipoDeNacionalidad
                };
            }
            catch (Exception e) {
                throw e;
            }
        }

        public ResponseNacionalidad GetNacionalidadByTipoNacionalidad(string TipoDeNacionalidad)
        {
            try
            {
                var db = new QueryFactory(_connection, _sqlKataCompiler);

                var nacionalidad = db.Query("Nacionalidad")
                    .Select("Nacionalidad.NacionalidadId", "Nacionalidad.TipoDeNacionalidad")
                    .Where("TipoDeNacionalidad", "=", TipoDeNacionalidad)
                    .FirstOrDefault<ResponseNacionalidad>();

                if (nacionalidad == null) {
                    throw new ArgumentNullException();
                }

                return nacionalidad;
            }
            catch (Exception e) {
                throw e;
            }
        }
    }
}
