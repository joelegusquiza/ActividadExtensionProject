using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Login
{
	public class LoginIndexViewModel
	{
		public LoginViewModel LoginModel { get; set; } = new LoginViewModel();
	}

	public class LoginViewModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public bool Recordar { get; set; }
	}
}
