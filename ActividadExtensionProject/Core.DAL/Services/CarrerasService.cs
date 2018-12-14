using ApplicationContext;
using Core.DAL.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DAL.Services
{
    public class CarrerasService : ICarreras
    {
        private readonly DataContext _context;

        public CarrerasService(DataContext context)
        {
            _context = context;
        }

        public IQueryable<Carrera> GetAll()
        {
            return _context.Set<Carrera>().Where(x => x.Active);
        }
    }
}
