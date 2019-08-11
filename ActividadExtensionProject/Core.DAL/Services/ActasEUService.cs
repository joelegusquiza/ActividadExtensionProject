using ApplicationContext;
using AutoMapper;
using Core.DAL.Interfaces;
using Core.DTOs.ActasEU;
using Core.DTOs.Shared;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Core.DAL.Services
{
    public class ActasEUService : IActasEU
    {
        private readonly IEstudiantes _estudiantes;
        private readonly DataContext _context;

        public ActasEUService(DataContext context, IEstudiantes estudiantes)
        {
            _context = context;
            _estudiantes = estudiantes;
        }

        public IQueryable<ActaEU> GetAll()
        {
            return _context.Set<ActaEU>().Include(x => x.Carrera).Include(x => x.Estudiante).Where(x => x.Active);
        }

		public ActaEU GetById(int id)
		{
			return GetAll().Include(x => x.ActaEUDetalle).FirstOrDefault(x => x.Id == id);
		}

		public ActaEU GetForView(int id)
		{
			return GetAll().Include(x => x.ActaEUDetalle).Include(x => x.Estudiante).FirstOrDefault(x => x.Id == id);
		}

		public IQueryable<ActaEUDetalle> GetDetalleInRange(DateTime inicio, DateTime fin)
		{
			return _context.Set<ActaEUDetalle>().Include(x => x.Acta).ThenInclude(x => x.Carrera).ThenInclude(x => x.Estudiantes).Include(x => x.Categoria).Include(x => x.SubCategoria).ThenInclude(x => x.Categoria).Where(x => x.FechaFin >= inicio && x.FechaFin <= fin );
		}

		public IQueryable<ActaEUDetalle> GetDetalleInRange(DateTime inicio, DateTime fin, int carreraId)
        {
            return _context.Set<ActaEUDetalle>().Include(x => x.Acta).ThenInclude(x => x.Carrera).ThenInclude(x => x.Estudiantes).Include(x => x.Categoria).Include(x => x.SubCategoria).ThenInclude(x => x.Categoria).Where(x => x.FechaFin >= inicio && x.FechaFin <= fin && x.Acta.CarreraId == carreraId);
        }

        public IQueryable<ActaEUDetalle> GetDetalleByMesAnhoCarrera(int mes, int anho, int carreraId)
        {
            return _context.Set<ActaEUDetalle>().Include(x => x.Acta).ThenInclude(x => x.Carrera).ThenInclude(x => x.Estudiantes).Include(x => x.Categoria).Include(x => x.SubCategoria).Where(x => x.FechaFin.Month == mes && x.FechaFin.Year == anho && x.Acta.CarreraId == carreraId);
        }

        public SystemValidationModel Save(AddActaEUViewModel viewModel)
        {
            var estudiante = _estudiantes.GetByCedulaIdentidad(viewModel.CedulaIdentidad);
            if (estudiante == null)
                return new SystemValidationModel() { Message = "No existe un estudiante registrado con la cedula de identidad", Success = false};
            var acta = new ActaEU()
            {
                EstudianteId = estudiante.Id,
                CarreraId = viewModel.CarreraSeleccionadaId,
                
            };
            foreach (var categoria in viewModel.Categorias)
            {
                foreach (var subcategoria in categoria.Detalle)
                {
                    if (subcategoria.HorasExtensionRealizadas != 0 && subcategoria.HorasRelojRealizadas != 0)
                    {
                        var detalleActa = Mapper.Map<ActaEUDetalle>(subcategoria);

                        if (subcategoria.SubCategoriaId == 0)
                        {   //significa que la categoria no tiene subcategoria
                            detalleActa.CategoriaId = categoria.CategoriaId;
							detalleActa.SubCategoriaId = null;
                        }
                        else
                        {
                            detalleActa.SubCategoriaId = subcategoria.SubCategoriaId;
                        }
                        _context.Entry(detalleActa).State = EntityState.Added;
                        acta.ActaEUDetalle.Add(detalleActa);
                    }
                }
                
            }
            _context.Entry(acta).State = EntityState.Added;
            var actaId = _context.SaveChanges();
            var validation = new SystemValidationModel()
            {
                Id = actaId,
                Success = actaId > 0               
            };
            return validation;
        }

        public SystemValidationModel Desactivate(int id)
        {
            var acta = _context.Set<ActaEU>().Include(x => x.ActaEUDetalle).FirstOrDefault(x => x.Active && x.Id == id);
            acta.Active = false;
            _context.Entry(acta).State = EntityState.Modified;
            foreach (var detalle in acta.ActaEUDetalle)
            {
                detalle.Active = false;
                _context.Entry(detalle).State = EntityState.Modified;
            }
            var success = _context.SaveChanges() > 0;
            var validation = new SystemValidationModel()
            {
                Success = success,
                Message = success ? "Se ha elimiado correctamente el acta" : "No se pudo eliminar el acta"
            };
            return validation;
        }   
    }
}
