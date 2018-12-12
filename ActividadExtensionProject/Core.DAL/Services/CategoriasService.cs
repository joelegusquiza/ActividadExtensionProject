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
    public class CategoriasService : ICategorias
    {
        private readonly DataContext _context;

        public CategoriasService(DataContext context)
        {
            _context = context;
        }

        public IQueryable<Categoria> GetAllWithSubCategorias()
        {
            return _context.Set<Categoria>().Include(x => x.SubCategorias).Where(x => x.Active);
        }
    }
}
