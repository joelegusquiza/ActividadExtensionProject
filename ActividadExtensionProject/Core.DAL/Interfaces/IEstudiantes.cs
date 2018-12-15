using Core.DTOs.Estudiantes;
using Core.DTOs.Shared;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DAL.Interfaces
{
    public interface IEstudiantes
    {
        List<Estudiante> GetAll();
        Estudiante GetById(int id);
        Estudiante GetByCedulaIdentidad(string cedulaIdentidad);
        SystemValidationModel Add(UpsertEstudianteViewModel viewModel);
        SystemValidationModel Edit(UpsertEstudianteViewModel viewModel);
        SystemValidationModel Desactivate(int id);
    }
}
