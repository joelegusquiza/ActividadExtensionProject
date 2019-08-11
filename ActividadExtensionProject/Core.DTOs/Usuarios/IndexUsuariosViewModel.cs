using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Usuarios
{
	public class IndexUsuariosViewModel
	{
		public List<UsuariosViewModel> Usuarios { get; set; } = new List<UsuariosViewModel>();
	}

	public class UsuariosViewModel
	{
		public int Id { get; set; }		
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Email { get; set; }
	}
}
