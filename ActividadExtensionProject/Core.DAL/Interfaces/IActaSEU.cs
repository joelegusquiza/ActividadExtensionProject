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
        IQueryable<ActaEUDetalle> GetDetalleByMesAnho(int mes, int anho);
        SystemValidationModel Save(AddActaEUViewModel viewModel);
        SystemValidationModel Desactivate(int id);
    }
}
