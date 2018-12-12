using ApplicationContext;
using Core.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DAL.Services
{
    public class EstudiantesService : IEstudiantes
    {
        private readonly DataContext _context;

        public EstudiantesService(DataContext context)
        {
            _context = context;
        }
    }
}
