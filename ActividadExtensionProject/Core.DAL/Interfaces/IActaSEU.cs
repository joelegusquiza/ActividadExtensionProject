using ApplicationContext;
using Core.DTOs.ActasEU;
using Core.DTOs.Shared;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DAL.Interfaces
{
    public interface IActasEU
    {
        IQueryable<ActaEU> GetAll();
		ActaEU GetById(int id);
		ActaEU GetForView(int id);
		IQueryable<ActaEUDetalle> GetDetalleInRange(DateTime inicio, DateTime fin, int carreraId);
		IQueryable<ActaEUDetalle> GetDetalleInRange(DateTime inicio, DateTime fin);
		IQueryable<ActaEUDetalle> GetDetalleByMesAnhoCarrera(int mes, int anho, int carreraId);
        SystemValidationModel Save(AddActaEUViewModel viewModel);
        SystemValidationModel Desactivate(int id);
    }
}
