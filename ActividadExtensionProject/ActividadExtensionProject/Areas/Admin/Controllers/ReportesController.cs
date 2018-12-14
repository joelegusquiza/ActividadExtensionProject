using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DAL.Interfaces;
using Core.DTOs.Reportes;
using Microsoft.AspNetCore.Mvc;

namespace ActividadExtensionProject.Areas.Admin.Controllers
{
    public class ReportesController : Controller
    {
        private readonly IActasEU _actasEU;
        public ReportesController(IActasEU actasEU)
        {
            _actasEU = actasEU;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ReporteMensualIndexViewModel GetReporteMensual(int mes, int year)
        {
            var viewModel = new ReporteMensualIndexViewModel();


            return viewModel;
        }
    }
}