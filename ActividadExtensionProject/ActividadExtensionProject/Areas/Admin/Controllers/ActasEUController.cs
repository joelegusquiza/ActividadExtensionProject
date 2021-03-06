﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DAL.Interfaces;
using Core.DTOs.ActasEU;
using Core.DTOs.Shared;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ActividadExtensionProject.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize("Admin")]
    public class ActasEUController : Controller
    {
        private readonly IActasEU _actasEU;
        private readonly ICategorias _categorias;
        private readonly ICarreras _carreras;
        public ActasEUController(IActasEU actasEU, ICategorias categorias, ICarreras carreras)
        {
            _actasEU = actasEU;
            _categorias = categorias;
            _carreras = carreras;
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
            var categorias = _categorias.GetAllWithSubCategorias();
            viewModel.CarrerasExistentes = _carreras.GetAll().Select(x => new DropDownViewModel<int>()
            {
                Text = $"{x.Abreviatura} - {x.Nombre}",
                Value = x.Id
            }).ToList();
            foreach (var categoria in categorias)
            {
                var categoriaTemp = AutoMapper.Mapper.Map<AddActaEUCategoriaViewModel>(categoria);
               
                foreach (var subCategoria in categoria.SubCategorias.Where(x => x.Active))
                {
                    var detalle = AutoMapper.Mapper.Map<AddActaEUDetalleViewModel>(subCategoria);
                    categoriaTemp.Detalle.Add(detalle);
                }
                //si la categoria no tiene subcategorias se le agrega esa categoria como subcategoria para mostrar en la vista
                if (categoria.SubCategorias.Count == 0)
                {
                    var subCat = new AddActaEUDetalleViewModel()
                    {
                        Nombre = categoria.Nombre,
                        Caracter = categoria.Caracter,                     
                    };
                    categoriaTemp.Detalle.Add(subCat);
                }
                viewModel.Categorias.Add(categoriaTemp);                

            }
            return View(viewModel);
        }

		public IActionResult View(int id)
		{
			var viewModel = new ViewActaEUViewModel();
			var acta = _actasEU.GetById(id);
			var categorias = _categorias.GetAllWithSubCategorias();
			viewModel.CarrerasExistentes = _carreras.GetAll().Select(x => new DropDownViewModel<int>()
			{
				Text = $"{x.Abreviatura} - {x.Nombre}",
				Value = x.Id
			}).ToList();
			viewModel = Mapper.Map(acta, viewModel);
			foreach (var categoria in categorias)
			{
				var categoriaTemp = Mapper.Map<AddActaEUCategoriaViewModel>(categoria);

				foreach (var subCategoria in categoria.SubCategorias.Where(x => x.Active))
				{
					var detalle = Mapper.Map<AddActaEUDetalleViewModel>(subCategoria);
					var savedDetalle = acta.ActaEUDetalle.FirstOrDefault(x => x.SubCategoriaId == subCategoria.Id);
					if (savedDetalle != null)
						detalle = Mapper.Map(savedDetalle, detalle);
					categoriaTemp.Detalle.Add(detalle);
				}
				//si la categoria no tiene subcategorias se le agrega esa categoria como subcategoria para mostrar en la vista
				if (categoria.SubCategorias.Count == 0)
				{
					var subCat = new AddActaEUDetalleViewModel()
					{
						Nombre = categoria.Nombre,
						Caracter = categoria.Caracter,
					};
					var savedDetalle = acta.ActaEUDetalle.FirstOrDefault(x => x.CategoriaId == categoria.Id);
					if (savedDetalle != null)
						subCat = Mapper.Map(savedDetalle, subCat);
					categoriaTemp.Detalle.Add(subCat);
				}
			
				viewModel.Categorias.Add(categoriaTemp);

			}
		
			
			return View(viewModel);
		}

        [HttpPost]
        public SystemValidationModel Save (string model)
        {
            var viewModel = JsonConvert.DeserializeObject<AddActaEUViewModel>(model);
            var validation = _actasEU.Save(viewModel);
            if (validation.Success)
                validation.Message = Url.Action("Index", "ActasEu", new { area = "Admin" });
            return validation;
        }

        [HttpPost]
        public SystemValidationModel Desactivate(int id)
        {           
            return _actasEU.Desactivate(id);
        }
    }
}