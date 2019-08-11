using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ActividadExtensionProject.SecurityHelpers;
using Core.DAL.Interfaces;
using Core.DTOs.Login;
using Core.DTOs.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ActividadExtensionProject.Areas.Shared.Controllers
{
	[Area("Shared")]
    public class LoginController : Controller
    {
		private readonly IUsuarios _usuarios;
		public LoginController(IUsuarios usuarios)
		{
			_usuarios = usuarios;
		}
        public IActionResult Index()
        {
			var viewModel = new LoginIndexViewModel();
            return View(viewModel);
        }

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Login", new { area = "Shared" });
		}


		[HttpPost]
		public async Task<SystemValidationModel> Login(string model)
		{
			try
			{
				var viewModel = JsonConvert.DeserializeObject<LoginViewModel>(model);
				var usuario = _usuarios.GetForLogin(viewModel.Email);
				if (usuario == null)
					return new SystemValidationModel() { Success = false, Message = "El usuario no existe" };
				var success = usuario.CheckPassword(viewModel.Password);
				if (success)
				{				
					var claims = new ClaimsIdentity(SecurityHelper.GetUserClaims(usuario), "Cookie");				
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims));
					return new SystemValidationModel() { Success = true, Message = "Login Exitoso", Url = Url.Action("Index", "Dashboard", new { area = "admin" }) };
				}
				return new SystemValidationModel() { Success = false, Message = "Password Incorrecto" };
			}
			catch (Exception ex)
			{
				throw;
			}

		}

		[HttpPost]
		public async Task<SystemValidationModel> Logout(string model)
		{
			try
			{
				var viewModel = JsonConvert.DeserializeObject<LoginViewModel>(model);
				var usuario = _usuarios.GetForLogin(viewModel.Email);
				if (usuario == null)
					return new SystemValidationModel() { Success = false, Message = "El usuario no existe" };
				var success = usuario.CheckPassword(viewModel.Password);
				if (success)
				{
					var claims = new ClaimsIdentity(SecurityHelper.GetUserClaims(usuario), "Cookie");
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims));
					return new SystemValidationModel() { Success = true, Message = "Login Exitoso", Url = Url.Action("Index", "Dashboard", new { area = "admin" }) };
				}
				return new SystemValidationModel() { Success = false, Message = "Password Incorrecto" };
			}
			catch (Exception ex)
			{
				throw;
			}

		}
	}
}