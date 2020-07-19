using MS.Persona.API.Entities;
using MS.Persona.Application.Services;
using MS.Persona.Domain.Commands;
using MS.Persona.Domain.DTOs;
using MS.Persona.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class ServicioPersona : IServicioPersona
    {
        private readonly IGenericsRepository _repository;
        private readonly IPersonaQuery _query;
        private readonly IServiceGenero _serviceGenero;
        private readonly IServiceLocalidad _serviceLocalidad;
        private readonly IServiceProvincia _serviceProvincia;
        private readonly IServiceEstadoCivil _serviceEstadoCivil;
        private readonly IServiceNacionalidad _serviceNacionalidad;


        public ServicioPersona(IGenericsRepository repository, IPersonaQuery query, IServiceGenero serviceGenero,
                                IServiceLocalidad serviceLocalidad, IServiceProvincia serviceProvincia,
                                IServiceEstadoCivil serviceEstadoCivil, IServiceNacionalidad serviceNacionalidad)
        {
            this._repository = repository;
            this._query = query;
            this._serviceGenero = serviceGenero;
            this._serviceLocalidad = serviceLocalidad;
            this._serviceProvincia = serviceProvincia;
            this._serviceEstadoCivil = serviceEstadoCivil;
            this._serviceNacionalidad = serviceNacionalidad;
        }

        public ResponsePersonaConId GetPersonaByDNI(int Dni)
        {
            ResponsePersonaConId aPerson = _query.GetPersonaByDNI(Dni);
            ResponseGeneros aGenero = _serviceGenero.GetGeneroByGeneroId(aPerson.GeneroId);
            EstadoCivilDto aEstadoCivil = _serviceEstadoCivil.GetEstadoCivilDTOByEstadoCivilId(aPerson.EstadoCivilId);
            ResponseNacionalidad aNacionalidad = _serviceNacionalidad.GetNacionalidadByNacionalidadId(aPerson.NacionalidadId);
            LocalidadDto aLocalidad = _serviceLocalidad.GetLocalidadDTOByLocalidadId(aPerson.LocalidadId);
            ProvinciaDto aProvincia = _serviceProvincia.GetProvinciaDTOByProvinciaId(aPerson.ProvinciaId);

            aPerson.Genero = aGenero;
            aPerson.EstadoCivil = aEstadoCivil;
            aPerson.Nacionalidad = aNacionalidad;
            aPerson.Provincia = aProvincia;
            aPerson.Localidad = aLocalidad;

            return aPerson;
        }

        public int GetPersonaIdByDNI(int Dni)
        {
            return _query.GetPersonaIdByDNI(Dni);
        }

        public PersonaDto GetPersonaByID(int PersonaId)
        {
            return _query.GetPersonaByID(PersonaId);
        }

        public IEnumerable<PersonaDto> GetPersonas()
        {
            return _query.GetAllPersonas();
        }

        public int ModifyPersona(PersonaDatosModificablesString modelPersona)
        {
            LocalidadDto localidad = _serviceLocalidad.GetLocalidadDTOByNombreLocalidad(modelPersona.Localidad);
            ResponseGeneros genero = _serviceGenero.GetGeneroByTipoGenero(modelPersona.Genero);
            EstadoCivilDto estadocivil = _serviceEstadoCivil.GetEstadoCivilDTOByTipoEstadoCivil(modelPersona.EstadoCivil);

            var personaModify = new PersonaDatosModificables
            {
                Dni = modelPersona.Dni,
                Nombre = modelPersona.Nombre,
                Apellido = modelPersona.Apellido,
                Direccion = modelPersona.Direccion,
                LocalidadId = localidad.LocalidadId,
                GeneroId = genero.GeneroId,
                EstadoCivilId = estadocivil.EstadoCivilId,
            };

            return _query.ModifyPersona(personaModify);
        }

        public int ModifyFechaDefuncion(PersonaDefuncionDto modelDefuncion)
        {
            return _query.ModifyFechaDefuncion(modelDefuncion);
        }

        public int ModifyPersonaEstadoCivil(PersonaModificableEstadoCivil modelPersona)
        {

            EstadoCivilDto estadocivil = _serviceEstadoCivil.GetEstadoCivilDTOByTipoEstadoCivil(modelPersona.EstadoCivil);

            var personaModify = new PersonaEstadoCivil
            {
                Dni = modelPersona.Dni,
                EstadoCivil = estadocivil.EstadoCivilId,
            };

            return _query.ModifyPersonaEstadoCivil(personaModify);
        }

        public bool IsValid(PersonaDatosModificablesString personaDatosModificablesString)
        {
            if (personaDatosModificablesString.Dni == null)
            {
                return false;
            }
            if (personaDatosModificablesString.Nombre == null)
            {
                return false;
            }
            if (personaDatosModificablesString.Apellido == null)
            {
                return false;
            }
            if (personaDatosModificablesString.Direccion == null)
            {
                return false;
            }
            if (personaDatosModificablesString.EstadoCivil == null)
            {
                return false;
            }if (personaDatosModificablesString.Genero == null)
            {
                return false;
            }
            if (personaDatosModificablesString.Localidad == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsValidEstadoCivil(PersonaModificableEstadoCivil modelPersona)
        {
            if (modelPersona.Dni == null)
            {
                return false;
            }

            if (modelPersona.EstadoCivil == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public ResponsePersonaConId SetPersona(PersonaDto persona)
        {
            ResponsePersonaConId responsePersona = new ResponsePersonaConId();

            LocalidadDto localidad = _serviceLocalidad.GetLocalidadDTOByNombreLocalidad(persona.Localidad);
            ResponseGeneros genero = _serviceGenero.GetGeneroByTipoGenero(persona.Genero);
            ProvinciaDto provincia = _serviceProvincia.GetProvinciaDTOByNombreProvincia(persona.Provincia);
            EstadoCivilDto estadocivil = _serviceEstadoCivil.GetEstadoCivilDTOByTipoEstadoCivil(persona.EstadoCivil);
            ResponseNacionalidad nacionalidad = _serviceNacionalidad.GetNacionalidadByTipoNacionalidad(persona.Nacionalidad);

            var personaEntity = new Persona
            {
                Dni = persona.Dni,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                FechaNacimiento = persona.FechaNacimiento,
                GeneroId = genero.GeneroId,
                EstadoCivilId = estadocivil.EstadoCivilId,
                NacionalidadId = nacionalidad.NacionalidadId,
                LocalidadId = localidad.LocalidadId,
                Direccion = persona.Direccion,
                TieneHijos = persona.TieneHijos,
                FechaDefuncion = persona.FechaDefuncion
            };

            _repository.Add<Persona>(personaEntity);
            int personaId = GetPersonaIdByDNI(personaEntity.Dni);
            responsePersona.PersonaId = personaId;
            responsePersona.Dni = personaEntity.Dni;
            responsePersona.Nombre = personaEntity.Nombre;
            responsePersona.Apellido = personaEntity.Apellido;
            responsePersona.FechaNacimiento = personaEntity.FechaNacimiento;
            responsePersona.Genero = genero;
            responsePersona.GeneroId = genero.GeneroId;
            responsePersona.EstadoCivil = estadocivil;
            responsePersona.EstadoCivilId = estadocivil.EstadoCivilId;
            responsePersona.Nacionalidad = nacionalidad;
            responsePersona.NacionalidadId = nacionalidad.NacionalidadId;
            responsePersona.Provincia = provincia;
            responsePersona.ProvinciaId = provincia.ProvinciaId;
            responsePersona.Localidad = localidad;
            responsePersona.LocalidadId = localidad.LocalidadId;
            responsePersona.Direccion = personaEntity.Direccion;
            responsePersona.TieneHijos = personaEntity.TieneHijos;
            responsePersona.FechaDefuncion = personaEntity.FechaDefuncion;
            return responsePersona;
        }
    }
}

