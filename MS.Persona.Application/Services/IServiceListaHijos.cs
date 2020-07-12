using MS.Persona.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.Application.Services
{
    public interface IServiceListaHijos
    {
        ResponseListaHijosDto GetHijosByPadreDni(int PadreDni);
        ResponseListaHijosDto SetHijos(RequestListaHijosDto listaHijos);
        bool PersonaExist(int Dni);

    }
}
