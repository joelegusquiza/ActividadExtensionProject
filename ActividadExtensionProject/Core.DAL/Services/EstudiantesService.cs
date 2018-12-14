﻿using ApplicationContext;
using Core.DAL.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Estudiante GetByCedulaIdentidad(string cedulaIdentidad)
        {
            return _context.Set<Estudiante>().FirstOrDefault(x => x.CedulaIdentidad == cedulaIdentidad && x.Active);
        }
    }
}
