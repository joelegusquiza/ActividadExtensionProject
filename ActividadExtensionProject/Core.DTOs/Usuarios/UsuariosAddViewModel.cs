using Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Core.Constants;

namespace Core.DTOs.Usuarios
{
	public class UsuariosAddViewModel
	{
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public SystemRoles Rol { get; set; }
		public List<DropDownViewModel<int>> Roles = Enum.GetValues(typeof(SystemRoles)).Cast<SystemRoles>().Select(x => new DropDownViewModel<int>
		{
			Text = x.ToString(),
			Value = (int)x
		}).ToList();
	}
}
