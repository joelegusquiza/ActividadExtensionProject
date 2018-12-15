using Core.DTOs.Reportes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DAL.Interfaces
{
    public interface IReportes
    {
        ReporteIndexViewModel GetReporteMensual(int mes, int anho, int carreraId);
    }
}
