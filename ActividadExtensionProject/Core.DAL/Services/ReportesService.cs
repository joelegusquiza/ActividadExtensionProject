using Core.DAL.Interfaces;
using Core.DTOs.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DAL.Services
{
    public class ReportesService : IReportes
    {
        private readonly IActasEU _actasEU;
        public ReportesService(IActasEU actasEU)
        {
            _actasEU = actasEU;
        }

        public ReporteIndexViewModel GetReporteMensual (int mes, int anho, int carreraId)
        {
            var actaDetalles = _actasEU.GetDetalleByMesAnhoCarrera(mes, anho, carreraId);
            var model = new ReporteIndexViewModel()
            {
                 Anho = anho,
                 Mes = mes,
                 CarreraId = carreraId
            };
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
                    model.Actividades.Add(tarea);
                }
                //model.Actividades.Add(actividad);
            }
            return model;
        }
    }
}
