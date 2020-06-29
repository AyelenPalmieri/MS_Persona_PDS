using MS.Persona.API.Entities;
using MS.Persona.Domain.Commands;
using MS.Persona.Domain.DTOs;
using MS.Persona.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Application.Services
{
    public class ServiceListaHijos : IServiceListaHijos
    {
        private readonly IGenericsRepository _repository;
        private readonly IListaHijosQuery _query;

        public ServiceListaHijos(IGenericsRepository repository, IListaHijosQuery query)
        {
            this._repository = repository;
            this._query = query;
        }

        public ResponseListaHijosDto GetHijosByPadreDni(int PadreDni)
        {
            return _query.GetHijosByPadreDni(PadreDni);
        }

        public ResponseListaHijosDto SetHijos(RequestListaHijosDto listaHijos)
        {
            bool personaTieneHijos = _query.PersonaTieneHijos(listaHijos.PadreDni);

            var hijosEntity = new ListaHijos
            {
                PadreDni = listaHijos.PadreDni,
                HijoDni = listaHijos.HijoDni
            };
            _repository.Add<ListaHijos>(hijosEntity);

            if (personaTieneHijos == false)
            {
                _query.ModifyTieneHijos(listaHijos.PadreDni);
            }

            return _query.GetHijosByPadreDni(listaHijos.PadreDni);
        }
    }
}
