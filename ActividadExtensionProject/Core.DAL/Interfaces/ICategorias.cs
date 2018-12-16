using Core.DTOs.Categorias;
using Core.DTOs.Shared;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DAL.Interfaces
{
    public interface ICategorias
    {
        Categoria GetById(int id);
        List<Categoria> GetAll();
        List<Categoria> GetAllWithSubCategorias();
        SystemValidationModel Save(AddCategoriaViewModel viewModel);
        SystemValidationModel Edit(EditCategoriaViewModel viewModel);
        SystemValidationModel Desactivate(int id);

    }
}
