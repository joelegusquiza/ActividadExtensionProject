using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DAL.Interfaces;
using Core.DTOs.Shared;
using Core.DTOs.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ActividadExtensionProject.Areas.Admin.Controllers
{
	[Area("Admin"), Authorize("Admin")]
	public class UsuariosController : Controller
    {
		public IUsuarios _usuarios;
		public UsuariosController(IUsuarios usuarios)
		{
			_usuarios = usuarios;
		}

        public IActionResult Index()
        {
			var viewModel = new IndexUsuariosViewModel()
			{
				Usuarios = Mapper.Map<List<UsuariosViewModel>>(_usuarios.GetAll())
			};
            return View(viewModel);
        }

		public IActionResult Add()
		{
			var viewModel = new UsuariosAddViewModel();
			return View(viewModel);
		}

		public IActionResult Edit(int id)
		{
			var viewModel = Mapper.Map<UsuariosEditViewModel>(_usuarios.GetById(id));
			return View(viewModel);
		}

		[HttpPost]
		public SystemValidationModel Add(string model)
		{
			var viewModel = JsonConvert.DeserializeObject<UsuariosAddViewModel>(model);
			var validation = _usuarios.Add(viewModel);
			if (validation.Success)
				validation.Message = Url.Action("Index", "Usuarios", new { area = "admin" });
			return validation;
		}

		[HttpPost]
		public SystemValidationModel Edit(string model)
		{
			var viewModel = JsonConvert.DeserializeObject<UsuariosEditViewModel>(model);
			var validation = _usuarios.Edit(viewModel);
			return validation;
		}

	}
}