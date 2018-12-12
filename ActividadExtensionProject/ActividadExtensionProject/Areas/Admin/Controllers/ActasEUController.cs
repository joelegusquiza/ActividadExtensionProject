using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DAL.Interfaces;
using Core.DTOs.ActasEU;
using Microsoft.AspNetCore.Mvc;

namespace ActividadExtensionProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ActasEUController : Controller
    {
        private readonly IActasEU _actasEU;
        private readonly ICategorias _categorias;
        public ActasEUController(IActasEU actasEU, ICategorias categorias)
        {
            _actasEU = actasEU;
            _categorias = categorias;
            
        }

        public IActionResult Index()
        {
            var viewModel = new IndexActaEUViewModel()
            {
                Actas = AutoMapper.Mapper.Map<List<ActaEUViewModel>>(_actasEU.GetAll().ToList())
            };
            return View(viewModel);
        }

        public IActionResult Add()
        {
            var viewModel = new AddActaEUViewModel();
            //getAllSubCategories
            var categorias = _categorias.GetAllWithSubCategorias();
    
            foreach (var categoria in categorias)
            {
                var categoriaTemp = AutoMapper.Mapper.Map<AddActaEUCategoriaViewModel>(categoria);
                foreach (var subCategoria in categoria.SubCategorias.Where(x => x.Active))
                {
                    var detalle = AutoMapper.Mapper.Map<AddActaEUDetalleViewModel>(subCategoria);
                    categoriaTemp.Detalle.Add(detalle);
                }
                viewModel.Categorias.Add(categoriaTemp);                

            }
            return View(viewModel);
        }
    }
}