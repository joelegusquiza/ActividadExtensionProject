using ApplicationContext;
using AutoMapper;
using Core.DAL.Interfaces;
using Core.DTOs.Carreras;
using Core.DTOs.Shared;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
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

        public List<Carrera> GetAll()
        {
            return _context.Set<Carrera>().Where(x => x.Active).ToList();
        }

        public Carrera GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public SystemValidationModel Add(UpsertCarreraViewModel viewModel)
        {
            var carrera = Mapper.Map<Carrera>(viewModel);           
            _context.Entry(carrera).State = EntityState.Added;
            var success = _context.SaveChanges() > 0;
            var validation = new SystemValidationModel()
            {
                Success = success,
                Id = carrera.Id
            };
            return validation;
        }

        public SystemValidationModel Edit(UpsertCarreraViewModel viewModel)
        {
            var carrera = GetById(viewModel.Id);
            carrera = Mapper.Map(viewModel, carrera);
            _context.Entry(carrera).State = EntityState.Modified;
            var success = _context.SaveChanges() > 0;
            var validation = new SystemValidationModel()
            {
                Success = success,
                Message = success ? "Se ha editado correctamente la carrera" : "No se pudo editar la carrera"
            };
            return validation;
        }

        public SystemValidationModel Desactivate(int id)
        {
            var carrera = GetById(id);
            carrera.Active = false;
            _context.Entry(carrera).State = EntityState.Modified;
            var success = _context.SaveChanges() > 0;
            var validation = new SystemValidationModel()
            {
                Success = success,
                Message = success ? "Se ha eliminado la carrera" : "No se pudo eliminar la carrera"
            };
            return validation;
        }
    }
}
