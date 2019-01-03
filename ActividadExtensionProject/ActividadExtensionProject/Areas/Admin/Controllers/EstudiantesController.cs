using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DAL.Interfaces;
using Core.DTOs.Estudiantes;
using Core.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Core.Constants;

namespace ActividadExtensionProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EstudiantesController : Controller
    {
        private readonly IEstudiantes _estudiantes;
        private readonly ICarreras _carreras;

        public EstudiantesController(IEstudiantes estudiantes, ICarreras carreras)
        {
            _estudiantes = estudiantes;
            _carreras = carreras;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexEstudianteViewModel()
            {
                Estudiantes = Mapper.Map<List<EstudianteViewModel>>(_estudiantes.GetAll())
            };
            return View(viewModel);
        }

        public IActionResult Upsert(int? id)
        {

            var viewModel = new UpsertEstudianteViewModel();
            if (id != null)
                viewModel = Mapper.Map<UpsertEstudianteViewModel>(_estudiantes.GetById(id.Value));

            viewModel.CarrerasExistentes = _carreras.GetAll().Select(x => new DropDownViewModel<int>()
            {
                Text = $"{x.Abreviatura} - {x.Nombre}",
                Value = x.Id
            }).ToList();

            viewModel.SexoExistentes = Enum.GetValues(typeof(Sexo)).Cast<Sexo>().Select(x => new DropDownViewModel<int>
            {
                Text = x.ToString(),
                Value = (int)x
            }).ToList();
            return View(viewModel);
        }

        public IActionResult AddEstudiante()
        {
            var viewModel = new UpsertEstudianteViewModel();
            viewModel.CarrerasExistentes = _carreras.GetAll().Select(x => new DropDownViewModel<int>()
            {
                Text = $"{x.Abreviatura} - {x.Nombre}",
                Value = x.Id
            }).ToList();

            viewModel.SexoExistentes = Enum.GetValues(typeof(Sexo)).Cast<Sexo>().Select(x => new DropDownViewModel<int>
            {
                Text = x.ToString(),
                Value = (int)x
            }).ToList();
            return View("~/Areas/Admin/Views/Estudiantes/Shared/AddEstudiante.cshtml", viewModel);
        }

        [HttpPost]
        public SystemValidationModel Upsert(string model)
        {
            var viewModel = JsonConvert.DeserializeObject<UpsertEstudianteViewModel>(model);
            var validation = new SystemValidationModel();
            if (viewModel.Id > 0)
            {
                validation = _estudiantes.Edit(viewModel);               
            }
            else
            {
                validation = _estudiantes.Add(viewModel);
                validation.Message = validation.Success ? Url.Action("Index", "Estudiantes", new { area = "Admin" }) : "No se pudo guardar el estudiante";
            }
            return validation;
        }

        [HttpPost]
        public SystemValidationModel Desactivate(int id)
        {
            return _estudiantes.Desactivate(id);
        }
    }
}