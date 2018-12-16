using ApplicationContext;
using AutoMapper;
using Core.DAL.Interfaces;
using Core.DTOs.Categorias;
using Core.DTOs.Shared;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DAL.Services
{
    public class CategoriasService : ICategorias
    {
        private readonly DataContext _context;

        public CategoriasService(DataContext context)
        {
            _context = context;
        }

        public List<Categoria> GetAll()
        {
            return _context.Set<Categoria>().Where(x => x.Active).ToList();
        }

        public Categoria GetById(int id)
        {
            return _context.Set<Categoria>().Include(x => x.SubCategorias).FirstOrDefault(x => x.Active && x.Id == id);
        }

        public List<Categoria> GetAllWithSubCategorias()
        {
            return _context.Set<Categoria>().Include(x => x.SubCategorias).Where(x => x.Active).ToList();
        }

        public SystemValidationModel Save(AddCategoriaViewModel viewModel)
        {
            var categoria = Mapper.Map<Categoria>(viewModel);
            _context.Entry(categoria).State = EntityState.Added;
            foreach (var subCategoria in viewModel.SubCategorias)
            {
                var subCategoriaEntity = Mapper.Map<SubCategoria>(subCategoria);
                _context.Entry(subCategoriaEntity).State = EntityState.Added;
                categoria.SubCategorias.Add(subCategoriaEntity);
            }
            var success = _context.SaveChanges() > 0;
            var validation = new SystemValidationModel()
            {
                Success = success,
                Id = categoria.Id
            };
            return validation;
        }

        public SystemValidationModel Edit(EditCategoriaViewModel viewModel)
        {
            var categoria = GetById(viewModel.Id);
            categoria = Mapper.Map(viewModel, categoria);
            _context.Entry(categoria).State = EntityState.Modified;

            var subCategoriaIdToDelete = categoria.SubCategorias.Select(x => x.Id).Except(viewModel.SubCategorias.Where(x => x.Id > 0).Select(x => x.Id));

            foreach (var subCategoria in categoria.SubCategorias.Where(x => subCategoriaIdToDelete.Contains(x.Id)))
            {
                _context.Entry(subCategoria).State = EntityState.Deleted;
            }


            foreach (var subCategoria in viewModel.SubCategorias.Where(x => x.Id == 0))
            {                
                var subCategoriaEntity = Mapper.Map<SubCategoria>(subCategoria);
                _context.Entry(subCategoriaEntity).State = EntityState.Added;
                categoria.SubCategorias.Add(subCategoriaEntity);
            }

            
            var success = _context.SaveChanges() > 0;
            var validation = new SystemValidationModel()
            {
                Success = success,
                Message = success ? "Se ha editado correctamente la categoria" : "No se pudo editar la categoria"
            };
            return validation;
        }

        public SystemValidationModel Desactivate (int id)
        {
            var categoria = GetById(id);
            categoria.Active = false;
            _context.Entry(categoria).State = EntityState.Modified;
            foreach (var subCategoria in categoria.SubCategorias)
            {
                subCategoria.Active = false;
                _context.Entry(subCategoria).State = EntityState.Modified;
            }
            var success = _context.SaveChanges() > 0;
            var validation = new SystemValidationModel()
            {
                Success = success,
                Message = success ? "Se ha eliminado correctamente la categoria" : "No se pudo eliminar la categoria"
            };
            return validation;
        }
    }
}
