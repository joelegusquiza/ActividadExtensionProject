using Core.DTOs.Reportes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DAL.Interfaces
{
    public interface IReportes
    {
        ReporteIndexViewModel GetReporteMensual(int mes, int anho, int carreraId);
        ReporteIndexViewModel GetReporteSemestral(int semestre, int anho, int carreraId);
        ReporteIndexViewModel GetReporteAnual(int anho, int carreraId);
    }
}
