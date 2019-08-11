using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Core.DAL.Interfaces;
using Core.DTOs.Reportes;
using Core.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ActividadExtensionProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportesController : Controller
    {
        private readonly IReportes _reportes;
        private readonly ICarreras _carreras;
        public ReportesController(IReportes reportes, ICarreras carreras)
        {
            _reportes = reportes;
            _carreras = carreras;
        }

        public IActionResult Mensual()
        {
            var viewModel = new ReporteIndexViewModel();
            //viewModel = _reportes.GetReporteMensual(12, 2018, 1);
            viewModel.CarrerasExistentes = _carreras.GetAll().Select(x => new DropDownViewModel<int>()
            {
                Text = $"{x.Abreviatura} - {x.Nombre}",
                Value = x.Id
            }).ToList();
            for (var i = 1; i <= 12; i++)
            {
                viewModel.MesesExistentes.Add(new DropDownViewModel<int>() { Text = CultureInfo.CreateSpecificCulture("es").DateTimeFormat.GetMonthName(i), Value = i });
            }
            for (var i = DateTime.Now.AddYears(-10).Year; i <= DateTime.Now.Year; i++)
            {
                viewModel.AnhosExistentes.Add(new DropDownViewModel<int>() { Text = i.ToString(), Value = i });
            }
            return View(viewModel);
            
        }

        public IActionResult Semestral()
        {
            var viewModel = new ReporteIndexViewModel();
            //viewModel = _reportes.GetReporteMensual(12, 2018, 1);
            viewModel.CarrerasExistentes = _carreras.GetAll().Select(x => new DropDownViewModel<int>()
            {
                Text = $"{x.Abreviatura} - {x.Nombre}",
                Value = x.Id
            }).ToList();
            for (var i = 1; i <= 2; i++)
            {
                viewModel.SemestresExistentes.Add(new DropDownViewModel<int>() { Text = i.ToString(), Value = i });
            }
            for (var i = DateTime.Now.AddYears(-10).Year; i <= DateTime.Now.Year; i++)
            {
                viewModel.AnhosExistentes.Add(new DropDownViewModel<int>() { Text = i.ToString(), Value = i });
            }
            return View(viewModel);

        }

        public IActionResult Anual()
        {
            var viewModel = new ReporteIndexViewModel();
            //viewModel = _reportes.GetReporteMensual(12, 2018, 1);
            viewModel.CarrerasExistentes = _carreras.GetAll().Select(x => new DropDownViewModel<int>()
            {
                Text = $"{x.Abreviatura} - {x.Nombre}",
                Value = x.Id
            }).ToList();           
            for (var i = DateTime.Now.AddYears(-10).Year; i <= DateTime.Now.Year; i++)
            {
                viewModel.AnhosExistentes.Add(new DropDownViewModel<int>() { Text = i.ToString(), Value = i });
            }
            return View(viewModel);

        }

		public IActionResult Actividades()
		{
			var viewModel = new ReporteActividadesIndexViewModel();
			return View(viewModel);
		}

        public ReporteIndexViewModel GetReporteMensual(int mes, int year, int carreraId)
        {
            var viewModel = _reportes.GetReporteMensual(mes, year, carreraId);        
            return viewModel;
        }

        public ReporteIndexViewModel GetReporteSemestral(int semestre, int year, int carreraId)
        {            
            var viewModel = _reportes.GetReporteSemestral(semestre, year, carreraId);
            return viewModel;
        }

        public ReporteIndexViewModel GetReporteAnual( int year, int carreraId)
        {
            var viewModel = _reportes.GetReporteAnual(year, carreraId);
            return viewModel;
        }

		public ReporteActividadesIndexViewModel GetReporteActividades(string parameter)
		{
			var parameterModel = JsonConvert.DeserializeObject<ReporteActividadParameter>(parameter);
			var viewModel = _reportes.GetReporteActividades(parameterModel.Inicio, parameterModel.Fin);
			viewModel.Actividades = viewModel.Actividades.OrderBy(x => x.Estudiante).ToList();
			return viewModel;
		}
	}
}