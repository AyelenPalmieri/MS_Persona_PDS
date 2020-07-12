using MS.Persona.Domain.DTOs;

namespace MS.Persona.Domain.Queries
{
    public interface IListaHijosQuery
    {
        ResponseListaHijosDto GetHijosByPadreDni(int PadreDni);
        bool PersonaTieneHijos(int PadreDni);
        int ModifyTieneHijos(int PadreDni);
        public bool PersonaExist(int Dni);
    }
}