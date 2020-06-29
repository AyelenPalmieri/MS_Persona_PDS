using MS.Persona.API.Entities;
using MS.Persona.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Persona.AccessData.Commands
{
    public class GenericsRepository : IGenericsRepository
    {
        private readonly MSPersonaDbContext _context;

        public GenericsRepository(MSPersonaDbContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

    }
}

