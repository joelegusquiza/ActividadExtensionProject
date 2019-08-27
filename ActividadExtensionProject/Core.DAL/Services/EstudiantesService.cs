using ApplicationContext;
using AutoMapper;
using Core.DAL.Interfaces;
using Core.DTOs.Estudiantes;
using Core.DTOs.Shared;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
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

        public List<Estudiante> GetAll()
        {
            return _context.Set<Estudiante>().Include(x => x.Carrera).Where(x => x.Active).ToList();
        }

        public Estudiante GetById(int id)
        {
            return _context.Set<Estudiante>().FirstOrDefault(x => x.Id == id);
        }

        public Estudiante GetByCedulaIdentidad(string cedulaIdentidad)
        {
            return _context.Set<Estudiante>().FirstOrDefault(x => x.CedulaIdentidad == cedulaIdentidad && x.Active);
        }

        public SystemValidationModel Edit(UpsertEstudianteViewModel viewModel)
        {
			var estudianteExist = _context.Set<Estudiante>().FirstOrDefault(x => x.CedulaIdentidad.Trim() == viewModel.CedulaIdentidad.Trim() && x.Id != viewModel.Id);
			if (estudianteExist != null)
			{
				return new SystemValidationModel() { Success = false, Message = "Ya existe un estudiante con la misma cedula de identidad" };
			}
			var estudiante = GetById(viewModel.Id);
            estudiante = Mapper.Map(viewModel, estudiante);
            _context.Entry(estudiante).State = EntityState.Modified;
            var success = _context.SaveChanges() > 0;
            var validation = new SystemValidationModel()
            {
                Success = success,
                Message = success ? "Se ha editado correctamente el estudiante" : "No se pudo editar el estudiante"
            };
            return validation;
        }

        public SystemValidationModel Add(UpsertEstudianteViewModel viewModel)
        {
            var estudiante = Mapper.Map<Estudiante>(viewModel);
			var estudianteExist = _context.Set<Estudiante>().FirstOrDefault(x => x.CedulaIdentidad.Trim() == viewModel.CedulaIdentidad.Trim());
			if (estudianteExist != null)
			{
				return new SystemValidationModel() { Success = false, Message = "Ya existe un estudiante con la misma cedula de identidad" };
			}
            _context.Entry(estudiante).State = EntityState.Added;
            var success = _context.SaveChanges() > 0;
            var validation = new SystemValidationModel()
            {
                Success = success,
                Id = estudiante.Id
            };
            return validation;
        }

        public SystemValidationModel Desactivate(int id)
        {
            var estudiante = GetById(id);
            estudiante.Active = false;
            _context.Entry(estudiante).State = EntityState.Modified;
            var success = _context.SaveChanges() > 0;
            var validation = new SystemValidationModel()
            {
                Success = success,
                Message = success ? "Se ha eliminado el estudiante" : "No se pudo eliminar el estudiante"
            };
            return validation;
        }
    }
}
