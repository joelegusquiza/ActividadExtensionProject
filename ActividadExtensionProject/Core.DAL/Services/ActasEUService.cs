using ApplicationContext;
using Core.DAL.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DAL.Services
{
    public class ActasEUService : IActasEU
    {
        private readonly DataContext _context;

        public ActasEUService(DataContext context)
        {
            _context = context;
        }

        public IQueryable<ActaEU> GetAll()
        {
            return _context.Set<ActaEU>().Include(x => x.Carrera).Include(x => x.Estudiante).Where(x => x.Active);
        }

      
    }
}
