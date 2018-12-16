using Core.DTOs.Carreras;
using Core.DTOs.Shared;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DAL.Interfaces
{
    public interface ICarreras
    {
        List<Carrera> GetAll();
        Carrera GetById(int id);
        SystemValidationModel Add(UpsertCarreraViewModel viewModel);
        SystemValidationModel Edit(UpsertCarreraViewModel viewModel);
        SystemValidationModel Desactivate(int id);
    }
}
