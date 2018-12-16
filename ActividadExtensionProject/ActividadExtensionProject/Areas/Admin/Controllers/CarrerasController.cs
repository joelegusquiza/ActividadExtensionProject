using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DAL.Interfaces;
using Core.DTOs.Carreras;
using Core.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ActividadExtensionProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarrerasController : Controller
    {
        private readonly ICarreras _carreras;

        public CarrerasController(ICarreras carreras)
        {
            _carreras = carreras;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexCarrerasViewModel()
            {
                Carreras = Mapper.Map<List<CarreraViewModel>>(_carreras.GetAll())
            };
            return View(viewModel);
        }

        public IActionResult Upsert(int? id)
        {
            var viewModel = new UpsertCarreraViewModel();
            if (id != null)
                viewModel = Mapper.Map<UpsertCarreraViewModel>(_carreras.GetById(id.Value));
            return View(viewModel);
        }

        [HttpPost]
        public SystemValidationModel Upsert(string model)
        {
            var viewModel = JsonConvert.DeserializeObject<UpsertCarreraViewModel>(model);
            var validation = new SystemValidationModel();
            if (viewModel.Id > 0)
            {
                validation = _carreras.Edit(viewModel);
            }
            else
            {
                validation = _carreras.Add(viewModel);
                validation.Message = validation.Success ? Url.Action("Index", "Carreras", new { area = "Admin" }) : "No se pudo guardar la carrera";
            }
            return validation;

        }

        [HttpPost]
        public SystemValidationModel Desactivate(int id)
        {
            return _carreras.Desactivate(id);
        }
    }
}