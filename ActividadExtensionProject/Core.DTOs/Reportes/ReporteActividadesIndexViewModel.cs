using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Reportes
{
	public class ReporteActividadesIndexViewModel
	{
		public ReporteActividadParameter Parameter { get; set; } = new ReporteActividadParameter();
		public List<ReporteActividadViewModel> Actividades { get; set; } = new List<ReporteActividadViewModel>();
	}

	public class ReporteActividadViewModel
	{
		public string Estudiante { get; set; }
		public string CedulaIdentidad { get; set; }
		public int Horas { get; set; }
		public string LugarTutor { get; set; }
		public string Caracter { get; set; }
	}

	public class ReporteActividadParameter 
	{
		public DateTime Inicio { get; set; } = DateTime.Now;
		public DateTime Fin { get; set; } = DateTime.Now;
	}
}
