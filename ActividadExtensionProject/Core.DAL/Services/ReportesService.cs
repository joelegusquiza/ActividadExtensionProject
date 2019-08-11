using ApplicationContext;
using Core.DAL.Interfaces;
using Core.DTOs.Reportes;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DAL.Services
{
    public class ReportesService : IReportes
    {
        private readonly IActasEU _actasEU;
		private readonly DataContext _context;
		public ReportesService(IActasEU actasEU, DataContext context)
        {
            _actasEU = actasEU;
			_context = context;
		}

        public ReporteIndexViewModel GetReporteMensual (int mes, int anho, int carreraId)
        {
            var actaDetalles = _actasEU.GetDetalleInRange(GetInicioMes(mes, anho), GetFinMes(mes, anho), carreraId).ToList();
            var model = new ReporteIndexViewModel()
            {
                 Anho = anho,
                 Mes = mes,
                 CarreraId = carreraId
            };
            model.Actividades = GetReporteList(actaDetalles);
            return model;
        }

        public ReporteIndexViewModel GetReporteSemestral(int semestre, int anho, int carreraId)
        {
            var actaDetalles = _actasEU.GetDetalleInRange(GetInicioSemestre(semestre, anho), GetFinSemestre(semestre, anho), carreraId).ToList();
            var model = new ReporteIndexViewModel()
            {
                Anho = anho,
                Semestre = semestre,
                CarreraId = carreraId
            };
            model.Actividades = GetReporteList(actaDetalles);
            return model;
        }

        public ReporteIndexViewModel GetReporteAnual(int anho, int carreraId)
        {
            var actaDetalles = _actasEU.GetDetalleInRange(new DateTime(anho, 1, 1), new DateTime(anho, 12, 31), carreraId).ToList();
            var model = new ReporteIndexViewModel()
            {
                Anho = anho,
                CarreraId = carreraId
            };
            model.Actividades = GetReporteList(actaDetalles);
            return model;
        }

		public ReporteActividadesIndexViewModel GetReporteActividades(DateTime inicio, DateTime fin) 
		{
			var modelToReturn = new ReporteActividadesIndexViewModel();
			var actaDetalles = _actasEU.GetDetalleInRange(inicio, fin ).ToList();
			foreach (var detalle in actaDetalles)
			{
				var item = new ReporteActividadViewModel()
				{
					CedulaIdentidad = detalle.Acta.Estudiante.CedulaIdentidad,
					Estudiante = $"{detalle.Acta.Estudiante.Apellido}, {detalle.Acta.Estudiante.Nombre}",
					Horas=detalle.HorasExtensionRealizadas,
					Caracter = detalle.SubCategoria == null ? detalle.Categoria.Caracter : detalle.SubCategoria.Caracter,
					LugarTutor = detalle.LugarProfesorTutor
				};
				modelToReturn.Actividades.Add(item);
			}
			return modelToReturn;
		}

        private List<ReporteItemViewModel> GetReporteList(List<ActaEUDetalle> actaDetalles)
        {
            List<ReporteItemViewModel> listToReturn = new List<ReporteItemViewModel>();
            foreach (var categoria in actaDetalles.Where(x => x.SubCategoriaId != null).Select(x => x.SubCategoria.Categoria))
            {
                //var actividad = new ReporteViewModel()
                //{
                //    ActividadEU = categoria.Nombre
                //};
                foreach (var subCategoria in actaDetalles.Where(x => x.SubCategoria.CategoriaId == categoria.Id).Select(x => x.SubCategoria))
                {
                    var detalles = actaDetalles.Where(x => x.SubCategoriaId == subCategoria.Id);
                    var tarea = new ReporteItemViewModel()
                    {
                        Tarea = subCategoria.Nombre,
                        BeneficiariosInstitucion = detalles.Select(x => x.Institucion).Distinct().Count(),
                        EjecutorMujer = detalles.Select(x => x.Acta.Estudiante).Where(x => x.Sexo == Constants.Sexo.Femenino).Count(),
                        EjecutorVaron = detalles.Select(x => x.Acta.Estudiante).Where(x => x.Sexo == Constants.Sexo.Masculino).Count(),
                        Lugar = string.Join(",", detalles.Select(x => x.LugarProfesorTutor)),
                        Cantidad = detalles.Count(),
                        ActividadEU = categoria.Nombre,
                        Organizador = detalles.FirstOrDefault().Acta.Carrera.Nombre
                    };
                    //actividad.Tareas.Add(tarea);
                    listToReturn.Add(tarea);
                }
                //model.Actividades.Add(actividad);
            }
            return listToReturn;
        }

        private DateTime GetInicioMes (int mes, int year)
        {
            return new DateTime(year, mes, 1);
        }

        private DateTime GetFinMes(int mes, int year) 
        {
            return GetInicioMes(mes, year).AddMonths(1).AddDays(-1);
        }

        private DateTime GetInicioSemestre(int semestre, int year)
        {
            switch (semestre)
            {
                case 1:
                    return new DateTime(year, 1, 1);
                case 2:
                    return new DateTime(year, 7, 1);
                default:
                    throw new NotImplementedException();
            }
        }

        private DateTime GetFinSemestre(int semestre, int year)
        {
            switch (semestre)
            {
                case 1:
                    return new DateTime(year, 6, 30);
                case 2:
                    return new DateTime(year, 12, 31);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
