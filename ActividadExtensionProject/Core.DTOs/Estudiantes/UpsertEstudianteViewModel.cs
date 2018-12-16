using Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.Constants;

namespace Core.DTOs.Estudiantes
{
    public class UpsertEstudianteViewModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string CedulaIdentidad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Sexo Sexo { get; set; }
        public int CarreraId { get; set; }

        public List<DropDownViewModel<int>> CarrerasExistentes { get; set; } = new List<DropDownViewModel<int>>();
        public List<DropDownViewModel<int>> SexoExistentes { get; set; } = new List<DropDownViewModel<int>>();
    }
}
