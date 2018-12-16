using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DAL.Interfaces;
using Core.DTOs.Categorias;
using Core.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ActividadExtensionProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly ICategorias _categorias;

        public CategoriasController(ICategorias categorias)
        {
            _categorias = categorias;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexCategoriasViewModel()
            {
                Categorias = Mapper.Map<List<CategoriaViewModel>>(_categorias.GetAll())
            };
            return View(viewModel);
        }

        public IActionResult Add()
        {
            var viewModel = new AddCategoriaViewModel();
            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var viewModel = Mapper.Map<EditCategoriaViewModel>(_categorias.GetById(id));
            return View(viewModel);
        }

        [HttpPost]
        public SystemValidationModel Save(string model)
        {
            var viewModel = JsonConvert.DeserializeObject<AddCategoriaViewModel>(model);
            var validation = _categorias.Save(viewModel);
            validation.Message = Url.Action("Index", "Categorias", new { area = "Admin" });
            return validation;
        }

        [HttpPost]
        public SystemValidationModel Edit(string model)
        {
            var viewModel = JsonConvert.DeserializeObject<EditCategoriaViewModel>(model);
            return _categorias.Edit(viewModel);
        }

        [HttpPost]
        public SystemValidationModel Desactivate(int id)
        {          
            return _categorias.Desactivate(id);
        }
    }
}