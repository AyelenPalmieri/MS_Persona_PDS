using MS.Persona.Domain.DTOs;
using MS.Persona.Domain.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using SqlKata.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MS.Persona.AccessData.Queries
{
    public class PersonaQuery : IPersonaQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _sqlKataCompiler;

        public PersonaQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this._connection = connection;
            this._sqlKataCompiler = sqlKataCompiler;
        }

        public List<PersonaDto> GetAllPersonas()
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var query = db.Query("Provincia")
                .Select("Persona.Dni", "Persona.Nombre", "Persona.Apellido", "Persona.Direccion",
                "Provincia.NombreProvincia", "Localidad.NombreLocalidad", "Nacionalidad.TipoDeNacionalidad", "EstadoCivil.TipoEstadoCivil",
                "Genero.TipoGenero")
                .Join("Localidad", j => j.On("Localidad.ProvinciaId", "Provincia.ProvinciaId"))
                .Join("Persona", j => j.On("Localidad.LocalidadId", "Persona.LocalidadId"))
                .Join("Genero", j => j.On("Genero.GeneroId", "Persona.GeneroId"))
                .Join("EstadoCivil", j => j.On("EstadoCivil.EstadoCivilId", "Persona.EstadoCivilId"))
                .Join("Nacionalidad", j => j.On("Nacionalidad.NacionalidadId", "Persona.NacionalidadId"));


            var result = query.Get<PersonaDto>();
            return result.ToList();

        }

        public PersonaDto GetPersonaByID(int PersonaId)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var persona = db.Query("Persona")
                .Select("Persona.Dni", "Persona.Nombre", "Persona.Apellido", "Persona.Fecha_Nacimiento",
                "Persona.GeneroId", "Persona.EstadoCivilId", "Persona.NacionalidadId", "Persona.LocalidadId",
                "Persona.Direccion", "Persona.ListaHijosId", "Persona.Fecha_Defuncion")
                .Where("PersonaId", "=", PersonaId)
                .FirstOrDefault<PersonaDto>();

            if (persona != null)
            {
                return new PersonaDto
                {
                    Dni = persona.Dni,
                    Nombre = persona.Nombre,
                    Apellido = persona.Apellido,
                    FechaNacimiento = persona.FechaNacimiento,
                    Genero = persona.Genero,
                    EstadoCivil = persona.EstadoCivil,
                    Nacionalidad = persona.Nacionalidad,
                    Localidad = persona.Localidad,
                    Direccion = persona.Direccion,
                    TieneHijos = persona.TieneHijos,
                    FechaDefuncion = persona.FechaDefuncion
                };
            }
            else
            {
                return null;
            }
        }

        public int ModifyPersona(PersonaDatosModificables modelPersona)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            int personaModificada = db.Query("Persona").Where("Dni", "=", modelPersona.Dni).Update(
                new
            {
                Nombre = modelPersona.Nombre,
                Apellido = modelPersona.Apellido,
                GeneroId = modelPersona.GeneroId,
                EstadoCivilId = modelPersona.EstadoCivilId,
                Direccion = modelPersona.Direccion,
                LocalidadId = modelPersona.LocalidadId,
            }) ;

            return personaModificada;
        }

        public ResponsePersonaConId GetPersonaByDNI(int Dni)
        {
            try
            {
                var db = new QueryFactory(_connection, _sqlKataCompiler);

                var persona = db.Query("Persona")
                    .Select("Persona.PersonaId", "Persona.Dni", "Persona.Nombre", "Persona.Apellido",
                    "Persona.GeneroId", "Persona.EstadoCivilId", "Persona.NacionalidadId", "Persona.LocalidadId",
                    "Persona.Direccion", "Persona.TieneHijos", "Persona.Fecha_Defuncion")
                    .Where("Dni", "=", Dni)
                    .FirstOrDefault<ResponsePersonaConId>();

                if (persona == null) {
                    //throw new System.ArgumentException("Persona no existe", "persona");
                    return new ResponsePersonaConId();
                }

                var datetime = db.Query("Persona")
                    .Select("Persona.Fecha_Nacimiento")
                    //.ForSqlServer(q => q.SelectRaw("CAST([DateTime] as DATETIME)"))
                    .Where("Dni", "=", Dni)
                    .FirstOrDefault<DateTime>().ToString("yyyy-MM-ddTHH:mm:ss");


                var provinciaDePersona = db.Query("Provincia")
                    .Select("Provincia.ProvinciaId", "Provincia.NombreProvincia")
                    .Where("Persona.DNI", $"{Dni}")
                    .Join("Localidad", "Localidad.ProvinciaId", "Provincia.ProvinciaId")
                    .Join("Persona", "Localidad.LocalidadId", "Persona.LocalidadId")
                    .FirstOrDefault<ProvinciaDto>();

                return new ResponsePersonaConId
                {
                    PersonaId = persona.PersonaId,
                    Dni = persona.Dni,
                    Nombre = persona.Nombre,
                    Apellido = persona.Apellido,
                    FechaNacimiento = Convert.ToDateTime(datetime),
                    GeneroId = persona.GeneroId,
                    EstadoCivilId = persona.EstadoCivilId,
                    NacionalidadId = persona.NacionalidadId,
                    LocalidadId = persona.LocalidadId,
                    ProvinciaId = provinciaDePersona.ProvinciaId,
                    Direccion = persona.Direccion,
                    TieneHijos = persona.TieneHijos,
                    FechaDefuncion = persona.FechaDefuncion
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int ModifyFechaDefuncion(PersonaDefuncionDto modelDefuncion)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            int affected = db.Query("Persona").Where("Dni", "=", modelDefuncion.Dni).Update(new
            {
                Fecha_Defuncion = Convert.ToDateTime(modelDefuncion.FechaDefuncion),
            });

            return affected;
        }

        public int GetPersonaIdByDNI(int Dni)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var personaId = db.Query("Persona")
                .Select("Persona.PersonaId")
                .Where("Dni", "=", Dni)
                .FirstOrDefault<int>();

            return personaId;

        }


    }
}
