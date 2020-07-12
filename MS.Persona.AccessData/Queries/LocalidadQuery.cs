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
    public class LocalidadQuery : ILocalidadQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _sqlKataCompiler;

        public LocalidadQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this._connection = connection;
            this._sqlKataCompiler = sqlKataCompiler;
        }

        public List<LocalidadDto> GetAllLocalidades()
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var query = db.Query("Localidad"); //select all

            var result = query.Get<LocalidadDto>();

            return result.ToList();
        }

        public LocalidadDto GetLocalidadDTOByNombreLocalidad(string NombreLocalidad)
        {
            try
            {
                var db = new QueryFactory(_connection, _sqlKataCompiler);

                var localidad = db.Query("Localidad")
                    .Select("Localidad.LocalidadId", "Localidad.NombreLocalidad")
                    .Where("NombreLocalidad", "=", NombreLocalidad)
                    .FirstOrDefault<LocalidadDto>();

                if (localidad == null) {
                    throw new ArgumentNullException();
                }

                return new LocalidadDto
                {
                    LocalidadId = localidad.LocalidadId,
                    NombreLocalidad = localidad.NombreLocalidad
                };
            }
            catch (Exception e){
                throw e;
            }
        }

        public LocalidadDto GetLocalidadByLocalidadId(int LocalidadId)
        {
            try
            {
                var db = new QueryFactory(_connection, _sqlKataCompiler);

                var localidad = db.Query("Localidad")
                    .Select("Localidad.LocalidadId", "Localidad.ProvinciaId", "Localidad.NombreLocalidad")
                    .Where("LocalidadId", "=", LocalidadId)
                    .FirstOrDefault<LocalidadDto>();

                if (localidad == null) {
                    return new LocalidadDto();
                }

                return new LocalidadDto
                {
                    LocalidadId = localidad.LocalidadId,
                    NombreLocalidad = localidad.NombreLocalidad
                };
            }
            catch (Exception e) {
                throw e;
            }
        }

        public ResponseLocalidadesPorProvinciaDto GetLocalidadesByNombreProvincia(string NombreProvincia)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var provincia = db.Query("Provincia")
                .Select("Provincia.ProvinciaId", "Provincia.NombreProvincia")
                .Where("Provincia.NombreProvincia", "=", NombreProvincia)
                .FirstOrDefault<ProvinciaDto>();

            var localidades = db.Query("Localidad")
                .Select("Localidad.ProvinciaId", "Localidad.NombreLocalidad", "Localidad.LocalidadId")
                .Where("Localidad.ProvinciaId", "=", provincia.ProvinciaId)
                .Get<LocalidadDto>()
                .ToList();

            return new ResponseLocalidadesPorProvinciaDto
            {
                ProvinciaId = provincia.ProvinciaId,
                NombreProvincia = provincia.NombreProvincia,
                Localidades = localidades
            };
        }

        public Localidad GetLocalidadByNombreLocalidad(string NombreLocalidad)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var localidad = db.Query("Localidad")
                .Select("Localidad.LocalidadId", "Localidad.NombreLocalidad")
                .Where("NombreLocalidad", "=", NombreLocalidad)
                .FirstOrDefault<Localidad>();

            return localidad;

        }
    }
}
