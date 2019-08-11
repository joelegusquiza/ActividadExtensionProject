using Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.ActasEU
{
	public class ViewActaEUViewModel
	{
		public int EstudianteId { get; set; }
		public string Estudiante { get; set; }
		public int CarreraId { get; set; }
		public string Carrera{ get; set; }
		public List<DropDownViewModel<int>> CarrerasExistentes { get; set; } = new List<DropDownViewModel<int>>();
		public List<AddActaEUCategoriaViewModel> Categorias { get; set; } = new List<AddActaEUCategoriaViewModel>();
	
	}

	
}
