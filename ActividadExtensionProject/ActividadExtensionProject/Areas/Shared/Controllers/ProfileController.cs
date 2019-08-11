using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DAL.Interfaces;
using Core.DTOs.Profile;
using Core.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ActividadExtensionProject.Areas.Shared.Controllers
{
	[Area("Shared")]
    public class ProfileController : BaseController
    {
		private readonly IUsuarios _usuarios;
		
		public ProfileController(IUsuarios usuarios)
		{
			_usuarios = usuarios;
			
		}
		public IActionResult Index()
		{
			var viewModel = Mapper.Map<ProfileViewModel>(_usuarios.GetById(UserId));
			return View(viewModel);
		}

		[HttpPost]
		public SystemValidationModel Modify(string model)
		{
			var viewModel = JsonConvert.DeserializeObject<ProfileViewModel>(model);
			return _usuarios.Edit(viewModel);
		}
	}
}