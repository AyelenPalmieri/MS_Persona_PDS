using MS.Persona.Domain.DTOs;
using MS.Persona.Domain.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MS.Persona.AccessData.Queries
{
    public class ListaHijosQuery : IListaHijosQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _sqlKataCompiler;

        public ListaHijosQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this._connection = connection;
            this._sqlKataCompiler = sqlKataCompiler;
        }

        public ResponseListaHijosDto GetHijosByPadreDni(int PadreDni)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var hijos = db.Query("ListaHijos")
                .Select("ListaHijos.ListaHijosId", "ListaHijos.HijoDni")
                .Where("PadreDni", "=", PadreDni)
                .Get<HijoDto>();


            return new ResponseListaHijosDto
            {
                PadreDni = PadreDni,
                Hijos = hijos.ToList()
            };
        }

        public bool PersonaTieneHijos(int PadreDni)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var estadoHijos = db.Query("Persona")
                .Select("Persona.TieneHijos")
                .Where("Dni", "=", PadreDni)
                .FirstOrDefault<bool>();

            return estadoHijos;
        }


        public int ModifyTieneHijos(int PadreDni)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            int affected = db.Query("Persona").Where("Dni", "=", PadreDni).Update(new
            {
                TieneHijos = true,
            });

            return affected;
        }
    }
}
