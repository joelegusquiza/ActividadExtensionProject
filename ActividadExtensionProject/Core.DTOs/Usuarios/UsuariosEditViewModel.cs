﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Usuarios
{
	public class UsuariosEditViewModel
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
